
namespace Layer.Entity.DataTranferObjects.ProductDtos
{
    public record ProductForUpdateDto : BaseDto
    {
        public int Id { get; init; }
        public bool IsActive { get; init; }
    }
}
