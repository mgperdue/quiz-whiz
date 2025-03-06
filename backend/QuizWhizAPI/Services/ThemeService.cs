#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class ThemeService : IThemeService
{
    private readonly AppDbContext _context;

    public ThemeService(AppDbContext context)
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