using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories.GenericBase;

namespace Layer.Repository.Repositories.Abstracts
{
    public interface ICategoryRepository : IGenericRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync(FeatureParams categoryParams,bool trackChanges);
        Task<Category?> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<Category?> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges);
        Task<int> GetAllCategoriesCountForPaginationAsync(string? searchTerm);
    }
}
