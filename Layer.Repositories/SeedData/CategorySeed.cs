

using Layer.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repository.SeedData
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var categories = new List<Category>();
            for(int i = 1;i <= 20; i++)
            {
                categories.Add(
                    new Category
                    {
                        Id = i,
                        CreatedDate = DateTime.Now,
                        Name = $"Category {i}",
                        Description = $"This is a description for category {i}"
                    }
                );
            }

            builder.HasData(categories);
        }
    }
}
