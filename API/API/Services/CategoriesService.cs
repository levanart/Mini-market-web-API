using API.Interfaces;
using API.Models;
using API.Repositories;

namespace API.Services;

public class CategoriesService : ICategoriesService
{
    private static int _availableId = 1;
    private InMemoryDataStore _dataStore;

    public CategoriesService(InMemoryDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public List<Category> GetAllCategories()
    {
        return _dataStore.Categories;
    }

    public Category? GetCategoryById(int id)
    {
        return _dataStore.Categories.FirstOrDefault(x => x.Id == id);
    }

    public Category CreateCategory(Category category)
    {
        category.Id = _availableId++;
        _dataStore.Categories.Add(category);
        return category;
    }

    public bool UpdateCategory(int id, Category category)
    {
        var oldCategory = _dataStore.Categories.FirstOrDefault(x => x.Id == id);
        if (oldCategory == null) return false;
        
        if(!string.IsNullOrEmpty(category.Name)) oldCategory.Name = category.Name;
        return true;
    }

    public bool DeleteCategory(int id)
    {
        var categoryToDelete = _dataStore.Categories.FirstOrDefault(x => x.Id == id);
        if (categoryToDelete == null) return false;
        
        _dataStore.Categories.Remove(categoryToDelete);
        return true;
    }
}