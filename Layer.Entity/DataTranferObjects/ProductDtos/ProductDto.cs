

using Layer.Entity.DataTranferObjects.CategoryDtos;

namespace Layer.Entity.DataTranferObjects.ProductDtos
{
    public record ProductDto : BaseDto
    {
        public int Id { get; init; }
        public bool StockStatus { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
        public CategoryDto Category { get; init; }
    }
}
