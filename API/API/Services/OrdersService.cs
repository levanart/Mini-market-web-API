using API.Interfaces;
using API.Models;
using API.Repositories;

namespace API.Services;

public class OrdersService : IOrdersService
{
    private static int _availableId = 1;
    private InMemoryDataStore _dataStore;
    public OrdersService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public List<Order> GetAllOrders()
    {
        return _dataStore.Orders;
    }

    public Order? GetOrderById(int id)
    {
        return _dataStore.Orders.FirstOrDefault(o => o.Id == id);
    }

    public Order CreateOrder(Order order)
    {
        Order orderToCreate = new();
        
        orderToCreate.OrderDate = DateTime.Now;
        orderToCreate.TotalPrice = 0;
        orderToCreate.DeletedProducts = new Dictionary<int, string>();

        foreach (var productId in order.Products)
        {
            var product = _dataStore.Products.FirstOrDefault(x => x.Id == productId);
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

        if (orderToCreate.Products.Count == 0) return orderToCreate;

        orderToCreate.Id = _availableId++;
        _dataStore.Orders.Add(orderToCreate);

        return orderToCreate;
    }
}