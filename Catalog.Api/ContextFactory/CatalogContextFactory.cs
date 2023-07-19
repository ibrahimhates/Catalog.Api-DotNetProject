using Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Api.ContextFactory
{
    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            // CatalogApi katmanındaki appsettings.json root dosyasını çek
            var configure = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Bu appsetting içinden conntectionstring getir
            var conn = configure.GetConnectionString("sqlConnectionString");

            // Conntectionstring ver ve ardından migrationların oluşacağı katmanı belirle
            var builder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(conn, p => p.MigrationsAssembly("CatalogApi"));

            // Ardından yeni bir context oluştur ve döndür
            return new CatalogContext(builder.Options);
        }
    }
}
