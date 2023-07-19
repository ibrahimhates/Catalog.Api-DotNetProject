
namespace Layer.Entity.Models
{
    public class Category : BaseModel
    {
        public ICollection<Product> Products { get; set; }
    }
}
