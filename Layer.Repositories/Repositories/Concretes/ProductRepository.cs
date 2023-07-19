using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Extensions;
using Layer.Repository.Repositories.Abstracts;
using Layer.Repository.Repositories.GenericBase;
using Microsoft.EntityFrameworkCore;

namespace Layer.Repository.Repositories.Concretes
{
    public class ProductRepository : GenericRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(
            FeatureParams productParams, bool trackChanges)
        {
            var products = await GetAll(trackChanges)
                .Search(productParams.SearchTerm)
                .ToPageList(productParams.PageSize, productParams.PageNumber)
                .ToListAsync();

            return products;
        }
        public async Task<IEnumerable<Product>> GetAllProductByCategoryIdAsync(
            FeatureParams productParams, int id, bool trackChanges)
        {
            var products = await
                GetByCondition(x => x.CategoryId == id, trackChanges)
                .Search(productParams.SearchTerm)
                .ToPageList(productParams.PageSize, productParams.PageNumber)
                .ToListAsync();

            return products;
        }

        public Task<Product?> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = GetByCondition(x => x.Id == id, trackChanges)
                .SingleOrDefaultAsync();

            return product;
        }

        public async Task<int> GetAllProductsCountForPagitanionAsync(string? searchTerm)
        {
            var count = await GetAll(false)
                .Search(searchTerm)
                .CountAsync();

            return count;
        }

        public async Task<int> GetAllProductsCountForPagitanionAsync(
            string? searchTerm, int id)
        {
            var count = await GetByCondition(x => x.CategoryId == id, false)
                .Search(searchTerm)
                .CountAsync();

            return count;
        }

    }
}
