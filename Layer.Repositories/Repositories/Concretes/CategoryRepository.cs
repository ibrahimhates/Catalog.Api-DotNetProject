
using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories.GenericBase;
using Layer.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Layer.Repository.Extensions;

namespace Layer.Repository.Repositories.Concretes
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync(FeatureParams categoryParams, bool trackChanges)
        {
            var categories = await GetAll(trackChanges)
                .Search(categoryParams.SearchTerm)
                .ToPageList(categoryParams.PageSize,categoryParams.PageNumber)
                .ToListAsync();

            return categories;
        }

        public Task<Category?> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = GetByCondition(x => x.Id == id, trackChanges)
                .SingleOrDefaultAsync();

            return category;
        }

        public async Task<Category?> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges)
        {
            var category = await GetByCondition(x => x.Id == id, trackChanges)
               .Include(x => x.Products)
               .SingleOrDefaultAsync();

            return category;
        }
        public async Task<int> GetAllCategoriesCountForPaginationAsync(string? searchTerm)
        {
            var count = await GetAll(false)
                .Search(searchTerm)
                .CountAsync();

            return count;
        }

    }
}
