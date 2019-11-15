using AutoMapper;
using Entities.Models;

namespace ProductsWebAPI.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductCreateInputModel, Product>();
            CreateMap<ProductUpdateInputModel, Product>();
        }
    }
}
