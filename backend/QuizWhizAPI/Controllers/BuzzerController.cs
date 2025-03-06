#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/buzzer")]
[ApiController]
public class BuzzerController : ControllerBase
{
    private readonly IBuzzerService _buzzerService;

    public BuzzerController(IBuzzerService buzzerService)
    {
        _buzzerService = buzzerService;
    }

    [HttpPost("{sessionId}/buzz")]
    public async Task<IActionResult> RegisterBuzz(int sessionId, [FromBody] int teamId)
    {
        var result = await _buzzerService.RegisterBuzz(sessionId, teamId);
        return Ok(result);
    }

    [HttpPost("{sessionId}/clear")]
    public async Task<IActionResult> ClearBuzzerQueue(int sessionId)
    {
        await _buzzerService.ClearQueue(sessionId);
        return NoContent();
    }
}