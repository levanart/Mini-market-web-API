using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private CategoriesService _categoriesService;
        public CategoriesController(CategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoriesService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoriesService.GetCategoryById(id);
            return category is not null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            var createdCategory = _categoriesService.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var isSuccess = _categoriesService.UpdateCategory(id, category);
            return isSuccess ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var isSuccess = _categoriesService.DeleteCategory(id);
            return isSuccess ? NoContent() : NotFound();
        }
    }
}