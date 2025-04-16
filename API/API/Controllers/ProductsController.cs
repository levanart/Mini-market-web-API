using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static readonly List<Product> Products = new List<Product>();
        static int _availableId = 1;

        [HttpGet]
        public IActionResult GetByCategory([FromQuery] int? categoryId)
        {
            if(categoryId == null || categoryId == 0) return Ok(Products);
            
            var productsToReturn = Products.Where(p => p.CategoryId == categoryId).ToList();
            return productsToReturn.Count == 0 ? NotFound($"Products with category id \"{categoryId}\" not found") : Ok(productsToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("search/{query}")]
        public IActionResult Get(string query)
        {
            var results = Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToList();
            
            return results.Count == 0 ? NotFound("No products found") : Ok(results);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (CategoriesController.Categories.Any(c => c.Id == product.CategoryId) == false) return NotFound($"Category \"{product.CategoryId}\" not found");
            product.Id = _availableId++;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var productToPut = Products.FirstOrDefault(x => x.Id == id);
            if (productToPut == null) return NotFound();
            
            productToPut.Name = product.Name;
            productToPut.CategoryId = product.CategoryId;
            productToPut.Price = product.Price;
            productToPut.Stock = product.Stock;
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productToDelete = Products.FirstOrDefault(x => x.Id == id);
            if (productToDelete == null) return NotFound();
            
            Products.Remove(productToDelete);
            
            return NoContent();
        }
    }
}