#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IThemeService
{
    Task<IEnumerable<ThemeSetting>> GetAllThemes();
    Task<ThemeSetting> GetThemeById(int id);
    Task<ThemeSetting> CreateTheme(ThemeSetting themeSetting);
}