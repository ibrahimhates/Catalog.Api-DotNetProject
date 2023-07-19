
using Layer.Entity.DataTranferObjects.ProductDtos;
using Layer.Entity.RequestFeatures;

namespace Layer.Service.Services.Abstracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto>,PaginationMetaData)> GetAllProductsAsync(
            FeatureParams productParams, bool trackChanges);
        Task<(IEnumerable<ProductDto>,PaginationMetaData)> GetAllProductByCategoryIdAsync(
            FeatureParams productParams, int id, bool trackChanges);
        Task<ProductDto?> GetOneProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto?> CreateOneProductAsync(ProductForInsertionDto productInsertionDto);
        Task UpdateOneProductAsync(ProductForUpdateDto productUpdateDto, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanges);
    }
}
