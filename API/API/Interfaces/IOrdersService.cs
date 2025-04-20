using API.Models;

namespace API.Interfaces;

public interface IOrdersService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(int id);
    Order CreateOrder(Order order);
}