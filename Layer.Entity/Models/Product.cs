
using System.Reflection.Metadata.Ecma335;

namespace Layer.Entity.Models
{
    public class Product : BaseModel
    {
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int TotalStock { get; set; }
        public int CurrentStock { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public bool StockStatus { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
