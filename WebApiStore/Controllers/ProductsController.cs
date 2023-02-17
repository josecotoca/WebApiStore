using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiStore.Entities;
using WebApiStore.Interfaces;
using WebApiStore.Dtos;
using WebApiStore.Repositories;
using WebApiStore.Tools;
using WebApiStore.Validators;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WebApiStore.Controllers
{
    
    [ApiController]
    [Route("api/v1/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct productRepository;
        private readonly IMapper mapper;
        private readonly IValidator<ProductDto> validator;
        public ProductsController(IProduct _productRepository, IMapper _mapper, IValidator<ProductDto> _validator)
        {
            productRepository = _productRepository;
            mapper = _mapper;
            validator = _validator;
        }

        [HttpGet]
        public  ActionResult<ProductDto> GetProducts()
        {
            try
            {
                var products = productRepository.GetAll();

                if(products == null)
                {
                    return ToolResponse.responseNotFound("");
                }

                var response = mapper.Map<List<ProductDto>>(products);

                return ToolResponse.responseOk(response);

            }
            catch (Exception ex)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody]ProductDto product)
        {
            try
            {
                if (await productRepository.ExistsByName(product.Name) == true) return ToolResponse.responseNotFound("No existe el producto.");
                var data = mapper.Map<Product>(product);
                await productRepository.Add(data);
                var response = mapper.Map<ProductDto>(data);

                return ToolResponse.responseCreated(response);
            } catch (Exception) {
                return ToolResponse.responseServerError();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductDto product, int id)
        {
            try
            {
                if (await productRepository.ExistsById(id) == false) return ToolResponse.responseNotFound("No existe el producto.");

                var productToUpdate = await productRepository.GetById(id);
                productToUpdate.forSale = product.ForSale;
                productToUpdate.isService = product.IsService;
                productToUpdate.Price = product.Price;
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Category= product.Category;

                await this.productRepository.Update(productToUpdate);
                var response = mapper.Map<ProductDto>(productToUpdate);

                return ToolResponse.responseAccepted(response);
            }
            catch (Exception)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                if (await productRepository.ExistsById(id) == false) return ToolResponse.responseNotFound("No existe el producto.");
                
                var product = await productRepository.GetById(id);
                var response = mapper.Map<ProductStockDto>(product);
                return ToolResponse.responseOk(response);
            }
            catch (Exception)
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (await productRepository.ExistsById(id) == false) return ToolResponse.responseNotFound("No existe el producto.");

                var productToDelete = await productRepository.GetById(id);

                await productRepository.Delete(productToDelete);

                return ToolResponse.responseNoContent();

            }
            catch (Exception)
            {
                return ToolResponse.responseServerError();
            }
        }


    }
}
