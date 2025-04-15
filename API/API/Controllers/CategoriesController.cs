using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static readonly List<Category> Categories = new();
        private static int _availableId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Categories;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return Categories.Any(x => x.Id == id) ? Ok(Categories.FirstOrDefault(x => x.Id == id)) : NotFound();
        }

        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            category.Id = _availableId++;
            Categories.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category category)
        {
            var oldCategory = Categories.FirstOrDefault(x => x.Id == id);
            if (oldCategory == null) return NotFound();
            
            oldCategory.Name = category.Name;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var categoryToDelete = Categories.FirstOrDefault(x => x.Id == id);
            if (categoryToDelete == null) return NotFound();
            
            Categories.Remove(categoryToDelete);
            return NoContent();
        }
    }
}