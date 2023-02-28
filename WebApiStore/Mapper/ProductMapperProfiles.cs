using AutoMapper;
using WebApiStore.Core.Entities;
using WebApiStore.Dtos.Product;

namespace WebApiStore.Mapper
{
    public class ProductMapperProfiles : Profile
    {
        public ProductMapperProfiles()
        {
            #region Dto for products
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            #endregion



        }
    }
}
