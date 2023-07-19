
namespace Layer.Entity.DataTranferObjects.CategoryDtos
{
    public record CategoryDto : BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
