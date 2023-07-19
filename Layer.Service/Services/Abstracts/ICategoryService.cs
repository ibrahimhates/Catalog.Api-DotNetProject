using Layer.Entity.DataTranferObjects.CategoryDtos;
using Layer.Entity.RequestFeatures;

namespace Layer.Service.Services.Abstracts
{
    public interface ICategoryService
    {
        Task<(IEnumerable<CategoryDto>, PaginationMetaData)> GetAllCategoriesAsync(
            FeatureParams productParams,bool trackChanges);
        Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDetailDto> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryForInsertionDto categoryDto);
        Task UpdateOneCategoryAsync(CategoryForUpdateDto categoryDto, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
