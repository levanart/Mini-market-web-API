using API.Models;

namespace API.Repositories;

public interface IDataStore
{
    List<Product> Products { get; set; }
    List<Category> Categories { get; set; }
    List<Order> Orders { get; set; }
}