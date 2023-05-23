using Microsoft.AspNetCore.Mvc;
using ProductManagementPlaftormAPI.Domain.Models;
using ProductManagementPlaftormAPI.Services;

namespace ProductManagementPlaftormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Category category = await _categoryService.GetCategoryByIdAsync(id);
            if (category is null)
            {
                return NotFound($"Cannot found id: {id} that  you provided");
            }
            return Ok(category);
        }

        [HttpPut]

        public async Task<IActionResult> Update(string id, [FromBody] Category category)
        {
            Category categoryUpdate = await   _categoryService.GetCategoryByIdAsync(id);  
            if(categoryUpdate is null)
            {
                return NotFound($"Cannot found {categoryUpdate}");
            }
            await _categoryService.UpdateCategoryAsync(category);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var category = _categoryService.GetCategoryByIdAsync(id);
            if (category is null)
            {
                return NotFound($"Cannot found id: {id} that you provided");
            }
            await _categoryService.DeleteCategoryByIdAsync(id);
            return Ok($"Category {id} deleted successfully");
        }
    }
}
