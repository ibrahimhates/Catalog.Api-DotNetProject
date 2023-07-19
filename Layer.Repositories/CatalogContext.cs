using Layer.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Layer.Repository
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) :base(options) { }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
