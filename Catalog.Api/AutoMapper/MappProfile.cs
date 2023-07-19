using AutoMapper;
using Layer.Entity.DataTranferObjects.CategoryDtos;
using Layer.Entity.DataTranferObjects.ProductDtos;
using Layer.Entity.Models;

namespace Catalog.Api.AutoMapper
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            // Category Mapping
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CategoryForInsertionDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            // Product Mapping
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForInsertionDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
        }
    }
}
