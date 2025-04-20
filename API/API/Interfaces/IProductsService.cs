using API.Models;

namespace API.Interfaces;

public interface IProductsService
{
    Product? GetProductByCategory(int? categoryId);
    Product? GetProductById(int id);
    List<Product> GetByPartName(string query);
    void CreateProduct(Product product);
    bool UpdateProduct(int id, Product product);
    bool DeleteProduct(int id);
}