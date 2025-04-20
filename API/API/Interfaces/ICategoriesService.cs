using API.Models;

namespace API.Interfaces;

public interface ICategoriesService
{
    List<Category> GetAllCategories();
    Category? GetCategoryById(int id);
    Category CreateCategory(Category category);
    bool UpdateCategory(int id, Category category);
    bool DeleteCategory(int id);
}