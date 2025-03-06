#region

using Microsoft.AspNetCore.Mvc;
using QuizWhizAPI.Models;
using QuizWhizAPI.Services;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayers();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayerById(int id)
    {
        var player = await _playerService.GetPlayerById(id);
        if (player == null) return NotFound();
        return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> CreatePlayer([FromBody] Player player)
    {
        var createdPlayer = await _playerService.CreatePlayer(player);
        return CreatedAtAction(nameof(GetPlayerById), new { id = createdPlayer.Id }, createdPlayer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var success = await _playerService.DeletePlayer(id);
        if (!success) return NotFound();
        return NoContent();
    }
}