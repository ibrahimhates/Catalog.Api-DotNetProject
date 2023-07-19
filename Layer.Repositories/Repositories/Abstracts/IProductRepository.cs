
using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories.GenericBase;

namespace Layer.Repository.Repositories.Abstracts
{
    public interface IProductRepository : IGenericRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductAsync(FeatureParams productParams, bool trackChanges);
        Task<IEnumerable<Product>> GetAllProductByCategoryIdAsync(
            FeatureParams productParams, int id, bool trackChanges);
        Task<Product?> GetOneProductByIdAsync(int id,bool trackChanges);
        Task<int> GetAllProductsCountForPagitanionAsync(string? searchTerm);
        Task<int> GetAllProductsCountForPagitanionAsync(string? searchTerm, int id);
    }
}
