#region

using Microsoft.AspNetCore.Mvc;
using QuizWhizAPI.Models;
using QuizWhizAPI.Services;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/themes")]
[ApiController]
public class ThemeController : ControllerBase
{
    private readonly IThemeService _themeService;

    public ThemeController(IThemeService themeService)
    {
        _themeService = themeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ThemeSetting>>> GetAllThemes()
    {
        var themes = await _themeService.GetAllThemes();
        return Ok(themes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ThemeSetting>> GetThemeById(int id)
    {
        var theme = await _themeService.GetThemeById(id);
        if (theme == null) return NotFound();
        return Ok(theme);
    }

    [HttpPost]
    public async Task<ActionResult<ThemeSetting>> CreateTheme([FromBody] ThemeSetting themeSetting)
    {
        var createdTheme = await _themeService.CreateTheme(themeSetting);
        return CreatedAtAction(nameof(GetThemeById), new { id = createdTheme.Id }, createdTheme);
    }
}