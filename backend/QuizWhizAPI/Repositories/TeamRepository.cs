using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllTeams()
    {
        return await _context.Teams.Include(t => t.Players).ToListAsync();
    }

    public async Task<Team> GetTeamById(int id)
    {
        return await _context.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Team> CreateTeam(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<Team> UpdateTeam(Team team)
    {
        var existingTeam = await _context.Teams.FindAsync(team.Id);
        if (existingTeam == null)
            return null;

        existingTeam.Name = team.Name;
        existingTeam.Color = team.Color;
        existingTeam.ImageUrl = team.ImageUrl;
        await _context.SaveChangesAsync();

        return existingTeam;
    }

    public async Task<bool> DeleteTeam(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task AssignPlayerToTeam(int playerId, int teamId)
    {
        var player = await _context.Players.FindAsync(playerId);
        var team = await _context.Teams.FindAsync(teamId);

        if (player == null || team == null)
            return;

        player.TeamId = teamId;
        await _context.SaveChangesAsync();
    }

    public async Task RemovePlayerFromTeam(int playerId)
    {
        var player = await _context.Players.FindAsync(playerId);
        if (player == null)
            return;

        player.TeamId = null;
        await _context.SaveChangesAsync();
    }
}