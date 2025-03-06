#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDbContext _context;

    public PlayerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<Player> GetPlayerById(int id)
    {
        return await _context.Players.FindAsync(id);
    }

    public async Task<Player> CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task<bool> DeletePlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return false;

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }
}