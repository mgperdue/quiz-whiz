#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class TeamService : ITeamService
{
    private readonly AppDbContext _context;

    public TeamService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllTeams()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team> GetTeamById(int id)
    {
        return await _context.Teams.FindAsync(id);
    }

    public async Task<Team> CreateTeam(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<bool> DeleteTeam(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }
}