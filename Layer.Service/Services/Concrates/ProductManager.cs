using AutoMapper;
using Layer.Entity.DataTranferObjects.ProductDtos;
using Layer.Entity.Exceptions.ProductException;
using Layer.Entity.Models;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories;
using Layer.Service.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Service.Services.Concrates
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager=manager;
            _mapper=mapper;
        }

        public async Task<(IEnumerable<ProductDto>, PaginationMetaData)> GetAllProductsAsync(
            FeatureParams productParams, bool trackChanges)
        {
            var products = await _manager
                .ProductRepository
                .GetAllProductAsync(productParams, trackChanges);

            var count = await _manager
                .ProductRepository
                .GetAllProductsCountForPagitanionAsync(productParams.SearchTerm);

            var metaData = CreateMetaDataForPagination(productParams,count);

            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return (productDtos, metaData);
        }

        public async Task<(IEnumerable<ProductDto>, PaginationMetaData)> GetAllProductByCategoryIdAsync(
            FeatureParams productParams, int id, bool trackChanges)
        {
            var products = await _manager
                .ProductRepository
                .GetAllProductByCategoryIdAsync(productParams, id, trackChanges);

            var count = await _manager
                .ProductRepository
                .GetAllProductsCountForPagitanionAsync(productParams.SearchTerm,id);

            var metaData = CreateMetaDataForPagination(productParams, count);

            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return (productDtos, metaData);
        }

        public async Task<ProductDto?> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await 
                GetOneProductCheckExistAsync(id, trackChanges);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }
        
        public async Task<ProductDto?> CreateOneProductAsync(ProductForInsertionDto productInsertionDto)
        {
            var product = _mapper.Map<Product>(productInsertionDto);
            product.StockStatus = product.CurrentStock==0 ? false : true;

            var categoryStatus = await CheckExistCategory(productInsertionDto.CategoryId);

            if (!categoryStatus)
                throw new ProductBadRequestException(productInsertionDto.CategoryId);

            product.CreatedDate = DateTime.Now;
            await _manager.ProductRepository.CreateAsync(product);

            await _manager.SaveAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateOneProductAsync(ProductForUpdateDto productUpdateDto, bool trackChanges)
        {
            var product = await 
                GetOneProductCheckExistAsync(productUpdateDto.Id, trackChanges);

            var categoryStatus = await CheckExistCategory(productUpdateDto.CategoryId);

            if (!categoryStatus)
                throw new ProductBadRequestException(productUpdateDto.CategoryId);

            product = _mapper.Map(productUpdateDto,product);
            product.StockStatus = product.CurrentStock==0 ? false : true;

            product.UpdatedDate = DateTime.Now;
            _manager.ProductRepository.Update(product);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            var product = await GetOneProductCheckExistAsync(id, trackChanges);

            _manager.ProductRepository.Delete(product);

            await _manager.SaveAsync();
        }

        private PaginationMetaData CreateMetaDataForPagination(
            FeatureParams productParams,int count)
        {
            return new PaginationMetaData()
            {
                TotalPage =  (int)Math.Ceiling(count/(double)productParams.PageSize),
                PageSize = productParams.PageSize,
                CurrentPage = productParams.PageNumber,
                TotalCount = count
            };
        }

        private async Task<Product> GetOneProductCheckExistAsync(int id,bool trackChanges)
        {
            var product = await _manager.
                ProductRepository
                .GetOneProductByIdAsync(id,trackChanges);

            if(product is null)
                throw new ProductNotFoundException(id);

            return product;
        } 

        private async Task<bool> CheckExistCategory(int id)
        {
            var result = await _manager
                .CategoryRepository
                .AnyAsync(x => x.Id == id, false);

            return result;
        }
    }
}
