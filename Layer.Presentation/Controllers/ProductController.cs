
using Layer.Entity.DataTranferObjects.ProductDtos;
using Layer.Entity.RequestFeatures;
using Layer.Service.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Layer.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService=productService;
        }

        [HttpGet("all/")]
        public async Task<IActionResult> GetAllProduct(
            [FromQuery]FeatureParams productParams)
        {
            var result = await _productService
                .GetAllProductsAsync(productParams,false);
            
            // result.Item2 is a paginationMetaData for Pagination
            Response.Headers.Add("Pagination-Detail",
                JsonSerializer.Serialize(result.Item2));

            // result.Item1 is a product list
            return Ok(result.Item1);
        }

        [HttpGet("allByCategory/{id:int}/")]
        public async Task<IActionResult> GetAllByCategoryId(
            [FromRoute(Name = "id")]int id,
            [FromQuery]FeatureParams productParams)
        {
            var result = await _productService
                .GetAllProductByCategoryIdAsync(productParams, id, false);

            // result.Item2 is a paginationMetaData for Pagination
            Response.Headers.Add("Pagination-Detail",
                JsonSerializer.Serialize(result.Item2));

            // result.Item1 is a product list
            return Ok(result.Item1);
        }

        [HttpGet("one/{id:int}/")]
        public async Task<IActionResult> GetOneProductById(
            [FromRoute(Name = "id")]int id)
        {
            var product = await _productService
                .GetOneProductByIdAsync(id, false);

            return Ok(product);
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateNewProduct(
            [FromBody]ProductForInsertionDto productForInsertion)
        {
            var createdProduct = await _productService
                .CreateOneProductAsync(productForInsertion);

            return StatusCode(201, createdProduct);
        }

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody]ProductForUpdateDto productForUpdate)
        {
            await _productService
                .UpdateOneProductAsync(productForUpdate, false);

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteOneProduct(
            [FromRoute(Name = "id")]int id)
        {
            await _productService
                .DeleteOneProductAsync(id, false);

            return NoContent();
        }

    }
}
