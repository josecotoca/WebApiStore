using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApiStore.Dtos;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using WebApiStore.Repositories;
using WebApiStore.Tools;

namespace WebApiStore.Controllers
{
    [ApiController]
    [Route("api/v1/transactions")]
    [Produces("application/json")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransaction transactionRepository;
        private readonly ITransactionDetail transactionDetailRepository;
        private readonly IMapper mapper;

        public TransactionsController(ITransaction _transactionRepository, ITransactionDetail _transactionDetailRepository, IMapper _mapper)
        {
            transactionRepository = _transactionRepository;
            mapper = _mapper;
            transactionDetailRepository = _transactionDetailRepository;
        }


        [HttpGet]
        public ActionResult<TransactionDto> GetTransactions()
        {
            try
            {
                var transactions = transactionRepository.GetAll();

                if (transactions == null)
                {
                    return ToolResponse.responseNotFound("");
                }

                var response = mapper.Map<List<TransactionDto>>(transactions);

                return ToolResponse.responseOk(response);

            }
            catch (Exception ex)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] TransactionDto transaction)
        {
            try
            {

                var data = mapper.Map<Transaction>(transaction);
                await transactionRepository.Add(data);

                if(await transactionDetailRepository.validateIsProduct(data.Detail) == false)
                    return ToolResponse.responseServerError("Producto no válido para mover inventario.");

                if (data.Type == ToolStr.TypeTransaction.EGRESO.ToString() && await transactionDetailRepository.hasStockAvailable(data.Detail) == false)
                    return ToolResponse.responseServerError("Producto con stock no disponible para mover inventario.");

                await transactionDetailRepository.moveStock(data.Detail,data.Id, data.Type);
                

                var response = mapper.Map<TransactionDto>(data);

                return ToolResponse.responseCreated(response);
            }
            catch (Exception ex)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            try
            {
                if (await transactionRepository.ExistsById(id) == false) return ToolResponse.responseNotFound("La transaccion de inventario no existe.");

                var transaction = await transactionRepository.GetById(id);
                var response = mapper.Map<TransactionDto>(transaction);
                return ToolResponse.responseOk(response);
            }
            catch (Exception)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                if (await transactionRepository.ExistsById(id) == false) return ToolResponse.responseNotFound("No existe la transaccion de inventario.");

                var transactionToDelete = await transactionRepository.GetById(id);
                //:TODO validate and ReverseStock

                await transactionRepository.Delete(transactionToDelete);

                return ToolResponse.responseNoContent();

            }
            catch (Exception)
            {
                return ToolResponse.responseServerError();
            }
        }

    }
}
