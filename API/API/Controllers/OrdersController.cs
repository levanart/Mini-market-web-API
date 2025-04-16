using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        static readonly List<Order> Orders = new List<Order>();
        static int _availableId = 1;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Orders.Any(x => x.Id == id) ? Ok(Orders.FirstOrDefault(x => x.Id == id)) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            Order orderToCreate = new();
            
            
            orderToCreate.OrderDate = DateTime.Now;
            orderToCreate.TotalPrice = 0;
            orderToCreate.DeletedProducts = new Dictionary<int, string>();
            

            foreach (var productId in order.Products)
            {
                var product = ProductsController.Products.FirstOrDefault(x => x.Id == productId);
                if (product == null)
                {
                    orderToCreate.DeletedProducts.Add(productId, "Product not found");
                    continue;
                }

                if (product.Stock == 0)
                {
                    orderToCreate.DeletedProducts.Add(productId, "Product stock is empty");
                    continue;
                }
                orderToCreate.Products.Add(product.Id);
                product.Stock--;
                orderToCreate.TotalPrice += product.Price;
            }

            if (orderToCreate.Products.Count == 0)
            {
                return NotFound(new
                {
                    message = "Cannot add any product from order",
                    deletedProducts = orderToCreate.DeletedProducts,
                });
            }
            
            orderToCreate.Id = _availableId++;
            Orders.Add(orderToCreate);
            
            return CreatedAtAction(nameof(Get), new { id = orderToCreate.Id }, orderToCreate);
        }
    }
}