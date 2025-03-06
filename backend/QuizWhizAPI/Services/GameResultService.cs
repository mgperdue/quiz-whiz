#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class GameResultService : IGameResultService
{
    private readonly AppDbContext _context;

    public GameResultService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameResult>> GetAllGameResults()
    {
        return await _context.GameResults.ToListAsync();
    }

    public async Task<GameResult> GetGameResultById(int id)
    {
        return await _context.GameResults.FindAsync(id);
    }

    public async Task<GameResult> SaveGameResult(GameResult gameResult)
    {
        _context.GameResults.Add(gameResult);
        await _context.SaveChangesAsync();
        return gameResult;
    }
}