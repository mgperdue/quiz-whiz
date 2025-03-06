#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int id);
    Task<Category> CreateCategory(Category category);
    Task<bool> DeleteCategory(int id);
}