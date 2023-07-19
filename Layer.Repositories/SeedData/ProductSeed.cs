
using Layer.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repository.SeedData
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var random = new Random();
            
            var products = new List<Product>();
            for(int i = 0; i < 300; i++)
            {
                var total = random.Next(100, 1000);
                var current = random.Next(0, 500);
                products.Add(
                    new Product()
                    {
                        Id = i+1,
                        Name = $"Product {i+1}",
                        Description = $"This is a description for product {i+1}",
                        Price = Convert.ToDecimal(random.Next(100, 100000)),
                        CreatedDate = DateTime.Now,
                        Manufacturer = $"Manufacturer for Product {i+1}",
                        TotalStock  = total,
                        CurrentStock = current>total?total:current,
                        IsActive = true,
                        StockStatus = current==0?false:true,
                        CategoryId = (i%20)+1
                    }
                 );
            }

            builder.HasData(products);
        }
    }
}
