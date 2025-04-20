using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsService _productsService;
        public ProductsController(ProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult GetProductByCategory([FromQuery] int? categoryId)
        {
            var productToReturn = _productsService.GetProductByCategory(categoryId);
            return productToReturn != null ? Ok(productToReturn) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productsService.GetProductById(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpGet("search/{query}")]
        public IActionResult GetByPartName(string query)
        {
            var results = _productsService.GetByPartName(query);
            
            return Ok(results);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                _productsService.CreateProduct(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            var isSuccess  = _productsService.UpdateProduct(id, product);
            if (!isSuccess) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isSuccess = _productsService.DeleteProduct(id);
            if (!isSuccess) return NotFound();
            
            return NoContent();
        }
    }
}