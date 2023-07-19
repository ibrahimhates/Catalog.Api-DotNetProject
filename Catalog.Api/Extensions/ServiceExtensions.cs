using Layer.Repository.Repositories.Abstracts;
using Layer.Repository.Repositories.Concretes;
using Layer.Repository.Repositories;
using Layer.Repository.UnitOfWork;
using Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Layer.Service.Services.Abstracts;
using Layer.Service.Services.Concrates;

namespace Catalog.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlConnection(
            this IServiceCollection services, IConfiguration configure)
        {
            var connectionString = configure.GetConnectionString("sqlConnectionString");
            services.AddDbContext<CatalogContext>(opt =>
                opt.UseSqlServer(connectionString)
            );
        }

        public static void ConfigureRepositoryInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void ConfigureUnitOfWorkInjection(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureRepoManagerInjection(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
        }
    }
}
