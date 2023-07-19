
namespace Layer.Entity.DataTranferObjects.ProductDtos
{
    public record BaseDto
    {
        private int stock = 0;
        public string Name { get; init; }
        public string? Description { get; init; }
        public string Manufacturer { get; init; }
        public decimal Price { get; init; }
        public decimal? DiscountedPrice { get; init; }
        public int TotalStock { get; init; }
        public int CurrentStock 
        { 
            get { return stock; } 
            init { stock = value<TotalStock ? value : TotalStock; }
        }
        public int CategoryId { get; init; }
    }
}
