
using Layer.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repository.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Manufacturer).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Price).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.DiscountedPrice).HasPrecision(18, 4);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.TotalStock).IsRequired();
            builder.Property(x => x.CurrentStock).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.StockStatus).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
