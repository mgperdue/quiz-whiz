#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/teams")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeams();
        return Ok(teams);
    }

    [HttpPost]
    public async Task<ActionResult<Team>> CreateTeam([FromBody] Team team)
    {
        var createdTeam = await _teamService.CreateTeam(team);
        return CreatedAtAction(nameof(GetAllTeams), new { id = createdTeam.Id }, createdTeam);
    }
}