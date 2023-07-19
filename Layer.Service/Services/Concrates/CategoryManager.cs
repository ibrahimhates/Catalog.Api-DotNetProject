
using AutoMapper;
using Layer.Entity.DataTranferObjects.CategoryDtos;
using Layer.Entity.Exceptions.CategoryException;
using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories;
using Layer.Service.Services.Abstracts;

namespace Layer.Service.Services.Concrates
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager=manager;
            _mapper=mapper;
        }

        public async Task<(IEnumerable<CategoryDto>,PaginationMetaData)> GetAllCategoriesAsync(
            FeatureParams categoryParams,bool trackChanges)
        {
            var categories = await _manager
                .CategoryRepository
                .GetAllCategoryAsync(categoryParams,trackChanges);

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);

            var count = await _manager
                .CategoryRepository
                .GetAllCategoriesCountForPaginationAsync(categoryParams.SearchTerm);

            var metaData = CreateMetaDataForPagination(categoryParams, count);
            return (categoryDtos,metaData);
        }
        public async Task<CategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await GetOneCategoryCheckExistAsync(id,trackChanges);
            
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
        public async Task<CategoryDetailDto> GetOneCategoryByIdWithProductAsync(int id, bool trackChanges)
        {
            var category = await _manager
                .CategoryRepository
                .GetOneCategoryByIdWithProductAsync(id,trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(id);

            var categoryDetailDto = _mapper.Map<CategoryDetailDto>(category);

            return categoryDetailDto;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryForInsertionDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _manager
                .CategoryRepository
                .CreateAsync(category);

            await _manager.SaveAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var category = await 
                GetOneCategoryCheckExistAsync(id, trackChanges);

            _manager.CategoryRepository.Delete(category);

            await _manager.SaveAsync();
        }
        public async Task UpdateOneCategoryAsync(CategoryForUpdateDto categoryDto, bool trackChanges)
        {
            var category = await 
                GetOneCategoryCheckExistAsync(categoryDto.Id, trackChanges);

            category = _mapper.Map(categoryDto, category);
            _manager.CategoryRepository.Update(category);


            await _manager.SaveAsync();
        }

        private PaginationMetaData CreateMetaDataForPagination(
            FeatureParams productParams, int count)
        {
            return new PaginationMetaData()
            {
                TotalPage =  (int)Math.Ceiling(count/(double)productParams.PageSize),
                PageSize = productParams.PageSize,
                CurrentPage = productParams.PageNumber,
                TotalCount = count
            };
        }

        private async Task<Category> GetOneCategoryCheckExistAsync(int id,bool trackChanges)
        {
            var category = await _manager
                .CategoryRepository
                .GetOneCategoryByIdAsync(id, trackChanges);

            if (category is null)
                throw new CategoryNotFoundException(id);

            return category;
        }
    }
}
