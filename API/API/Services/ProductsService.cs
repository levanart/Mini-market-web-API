using API.Models;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services;

public class ProductsService : IProductsService
{
    private IDataStore _dataStore;
    private static int _availableId = 1;

    public ProductsService(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Product? GetProductByCategory(int? categoryId)
    {
        var product = _dataStore.Products.FirstOrDefault(p => p.CategoryId == categoryId);
        return product;
    }

    public Product? GetProductById(int id)
    {
        return _dataStore.Products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetByPartName(string query)
    {
        return _dataStore.Products.Where(p => p.Name.ToLower().Contains(query.ToLower())).ToList();
    }

    public void CreateProduct(Product product)
    {
        if (!_dataStore.Categories.Any(p => p.Id == product.Id)) throw new Exception($"Category \"{product.Id}\" not found");
        product.Id = _availableId++;
        _dataStore.Products.Add(product);
    }

    public bool UpdateProduct(int id, Product product)
    {
        var productToChange = _dataStore.Products.FirstOrDefault(p => p.Id == id);
        if (productToChange == null) return false;

        if (!string.IsNullOrEmpty(product.Name)) productToChange.Name = product.Name;
        if (product.CategoryId is not 0 && product.CategoryId is not null)
            productToChange.CategoryId = product.CategoryId;
        if (product.Price is not 0) productToChange.Price = product.Price;
        if (product.Stock is not 0 && product.Stock is not null) productToChange.Stock = product.Stock;

        return true;
    }

    public bool DeleteProduct(int id)
    {
        var productToDelete = _dataStore.Products.FirstOrDefault(p => p.Id == id);
        if (productToDelete is null) return false;

        _dataStore.Products.Remove(productToDelete);

        return true;
    }
}