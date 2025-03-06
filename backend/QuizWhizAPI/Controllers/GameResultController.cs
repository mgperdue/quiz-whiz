#region

using Microsoft.AspNetCore.Mvc;
using QuizWhizAPI.Models;
using QuizWhizAPI.Services;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/gameresults")]
[ApiController]
public class GameResultController : ControllerBase
{
    private readonly IGameResultService _gameResultService;

    public GameResultController(IGameResultService gameResultService)
    {
        _gameResultService = gameResultService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameResult>>> GetAllGameResults()
    {
        var results = await _gameResultService.GetAllGameResults();
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameResult>> GetGameResultById(int id)
    {
        var result = await _gameResultService.GetGameResultById(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GameResult>> SaveGameResult([FromBody] GameResult gameResult)
    {
        var savedResult = await _gameResultService.SaveGameResult(gameResult);
        return CreatedAtAction(nameof(GetGameResultById), new { id = savedResult.Id }, savedResult);
    }
}