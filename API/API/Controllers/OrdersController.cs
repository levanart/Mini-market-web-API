using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrdersService _ordersService;
        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_ordersService.GetAllOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var orderToReturn = _ordersService.GetOrderById(id);
            return orderToReturn is not null ? Ok(orderToReturn) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            var createdOrder = _ordersService.CreateOrder(order);
            if (createdOrder.Products.Count == 0)
            {
                return NotFound(new
                {
                    message = "Cannot add any product from order",
                    deletedProducts = createdOrder.DeletedProducts,
                });
            }
            
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }
    }
}