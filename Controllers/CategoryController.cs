using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger,ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateCategory(categoryDto);
            return StatusCode(result.Status,result);
        }

        [HttpGet]
        [ValidateModel]
        public async Task<ActionResult> GetCategories([FromQuery] QueryPaginationDto queryPaginationDto)
        {
            var result = await _categoryService.GetCategories(queryPaginationDto);
            return StatusCode(result.Status,result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(Guid id)
        {
            var result = await _categoryService.GetCategoryById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateCategory(id,categoryDto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);
            return StatusCode(result.Status, result);
        }


    }
}