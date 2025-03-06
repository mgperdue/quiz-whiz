#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<bool> DeleteCategory(int id);
}