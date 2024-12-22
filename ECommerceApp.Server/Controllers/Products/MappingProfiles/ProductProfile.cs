using AutoMapper;
using ECommerceApp.Server.Controllers.Products.Dtos;
using ECommerceApp.Server.Models;

namespace ECommerceApp.Server.Controllers.Products.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Product to GetProductDto
            CreateMap<Product, GetProductDto>();

            // CreateProductDto to Product
            CreateMap<CreateProductDto, Product>();

            // UpdateProductDto to Product
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
