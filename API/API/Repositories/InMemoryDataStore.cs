using API.Models;

namespace API.Repositories;

public class InMemoryDataStore : IDataStore
{
    public List<Product> Products { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}