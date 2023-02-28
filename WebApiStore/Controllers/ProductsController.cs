using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApiStore.Application.Interfaces;
using WebApiStore.Core.Entities;
using WebApiStore.Dtos.Product;
using WebApiStore.Infraestructure.Repository;
using WebApiStore.Tools;
using WebApiStore.Core.Repositories;

namespace WebApiStore.Controllers
{
    [ApiController]
    [Route("api/v2/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
        }

        [HttpGet("GetById/{productId}")]
        public async Task<ActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await productService.GetProductById(productId);
                var response = mapper.Map<ProductDto>(product);

                return ToolResponse.responseOk(response);

            }
            catch (ApplicationException ex)
            {
                return ToolResponse.responseServerError(ex.Message.ToString());
            }
            catch {
                return ToolResponse.responseServerError();
            }
        }


        [Route("GetByName/{productName?}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByName([FromRoute] string? productName)
        {
            try
            {
                IEnumerable<ProductDto> response = Enumerable.Empty<ProductDto>();
                IEnumerable<Product> list = Enumerable.Empty<Product>();

                if (string.IsNullOrWhiteSpace(productName))
                    list = await productService.GetProductList();
                else
                    list = await productService.GetProductByName(productName);

                response = mapper.Map<IEnumerable<ProductDto>>(list);
                return ToolResponse.responseOk(response);
            }
            catch (Exception ex)
            {
                return ToolResponse.responseServerError(ex.Message.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductCreateDto productViewModel)
        {
            try
            {
                var mapped = mapper.Map<Product>(productViewModel);
                if (mapped == null) throw new Exception("La entidad no pudo cargar");

                var entityDto = await productService.Create(mapped);
                var response = mapper.Map<ProductDto>(entityDto);

                return ToolResponse.responseCreated(response);
            }
            catch (ApplicationException ex)
            {
                return ToolResponse.responseServerError(ex.Message.ToString());
            }
            catch
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDto productViewModel)
        {
            try
            {
                var mapped = mapper.Map<Product>(productViewModel);
                if (mapped == null) throw new ApplicationException("La entidad no se ha podido cargar.");

                await productService.Update(mapped);

                var response = mapper.Map<ProductDto>(mapped);

                return ToolResponse.responseAccepted(response);
            }
            catch (ApplicationException ex)
            {
                return ToolResponse.responseServerError(ex.Message.ToString());
            }
            catch
            {
                return ToolResponse.responseServerError();
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            
            try
            {
                await productService.Delete(productId);

                return ToolResponse.responseNoContent();
            }
            catch (ApplicationException ex)
            {
                return ToolResponse.responseServerError(ex.Message.ToString());
            }
            catch
            {
                return ToolResponse.responseServerError();
            }
        }
    }
}
