using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IThemeRepository
{
    Task<IEnumerable<ThemeSetting>> GetAllThemes();
    Task<ThemeSetting> GetThemeById(int id);
    Task<ThemeSetting> CreateTheme(ThemeSetting themeSetting);
}