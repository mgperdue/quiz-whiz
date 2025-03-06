#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.Categories.Include(c => c.CategoryQuestions).ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _context.Categories
            .Include(c => c.CategoryQuestions)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}