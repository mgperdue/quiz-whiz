#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/gamesessions")]
[ApiController]
public class GameSessionController : ControllerBase
{
    private readonly IGameSessionService _gameSessionService;

    public GameSessionController(IGameSessionService gameSessionService)
    {
        _gameSessionService = gameSessionService;
    }

    [HttpPost]
    public async Task<ActionResult<GameSession>> StartNewSession([FromBody] int gameBoardId)
    {
        var session = await _gameSessionService.StartGameSession(gameBoardId);
        return Ok(session);
    }

    [HttpPut("{sessionId}/end")]
    public async Task<IActionResult> EndSession(int sessionId)
    {
        await _gameSessionService.EndGameSession(sessionId);
        return NoContent();
    }
}