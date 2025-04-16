using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public static readonly List<Category> Categories = new();
        private static int _availableId = 1;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Categories.Any(x => x.Id == id) ? Ok(Categories.FirstOrDefault(x => x.Id == id)) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            category.Id = _availableId++;
            Categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var oldCategory = Categories.FirstOrDefault(x => x.Id == id);
            if (oldCategory == null) return NotFound();
            
            oldCategory.Name = category.Name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoryToDelete = Categories.FirstOrDefault(x => x.Id == id);
            if (categoryToDelete == null) return NotFound();
            
            Categories.Remove(categoryToDelete);
            return NoContent();
        }
    }
}