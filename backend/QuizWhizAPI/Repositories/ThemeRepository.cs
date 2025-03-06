using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public class ThemeRepository : IThemeRepository
{
    private readonly AppDbContext _context;

    public ThemeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ThemeSetting>> GetAllThemes()
    {
        return await _context.ThemeSettings.ToListAsync();
    }

    public async Task<ThemeSetting> GetThemeById(int id)
    {
        return await _context.ThemeSettings.FindAsync(id);
    }

    public async Task<ThemeSetting> CreateTheme(ThemeSetting themeSetting)
    {
        _context.ThemeSettings.Add(themeSetting);
        await _context.SaveChangesAsync();
        return themeSetting;
    }
}