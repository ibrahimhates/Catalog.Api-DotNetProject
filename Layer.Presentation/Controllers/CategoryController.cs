
using Layer.Entity.DataTranferObjects.CategoryDtos;
using Layer.Entity.RequestFeatures;
using Layer.Repository.Repositories.Abstracts;
using Layer.Service.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Layer.Presentation.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all/")]
        public async Task<IActionResult> GetAllCategories(
            [FromQuery]FeatureParams categoryParams)
        {
            var result = await _categoryService
                .GetAllCategoriesAsync(categoryParams, false);

            Response.Headers.Add("Pagination-Detail",
                JsonSerializer.Serialize(result.Item2));

            return Ok(result.Item1);
        }

        [HttpGet("one/{id:int}/")]
        public async Task<IActionResult> GetOneCategory(
            [FromRoute(Name = "id")]int id)
        {
            var category = await _categoryService
                .GetOneCategoryByIdAsync(id, false);

            return Ok(category);
        }

        [HttpGet("oneDetail/{id:int}/")]
        public async Task<IActionResult> GetOneCategoryWithProduct(
            [FromRoute(Name = "id")] int id)
        {
            var categoryDetail = await _categoryService
                .GetOneCategoryByIdWithProductAsync(id, false);

            return Ok(categoryDetail);
        }

        [HttpPost("create/")]
        public async Task<IActionResult> CreateNewCategory(
            [FromBody]CategoryForInsertionDto categoryForInsertion)
        {
            var category = await _categoryService
                .CreateOneCategoryAsync(categoryForInsertion);

            return StatusCode(201,category);
        }

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateCategory(
            [FromBody]CategoryForUpdateDto categoryForUpdate)
        {
            await _categoryService
                .UpdateOneCategoryAsync(categoryForUpdate, false);

            return NoContent();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteCategory(
            [FromRoute(Name = "id")]int id)
        {
            await _categoryService
                .DeleteOneCategoryAsync(id,false);

            return NoContent();
        }
    }
}
