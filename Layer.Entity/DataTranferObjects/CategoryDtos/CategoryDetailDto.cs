using Layer.Entity.DataTranferObjects.ProductDtos;

namespace Layer.Entity.DataTranferObjects.CategoryDtos
{
    public record CategoryDetailDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
