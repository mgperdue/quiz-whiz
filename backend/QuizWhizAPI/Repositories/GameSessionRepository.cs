using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public class GameSessionRepository : IGameSessionRepository
{
    private readonly AppDbContext _context;

    public GameSessionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameSession>> GetAllGameSessions()
    {
        return await _context.GameSessions.Include(gs => gs.Teams).ToListAsync();
    }

    public async Task<GameSession> GetGameSessionById(int id)
    {
        return await _context.GameSessions
            .Include(gs => gs.Teams)
            .FirstOrDefaultAsync(gs => gs.Id == id);
    }

    public async Task<GameSession> CreateGameSession(GameSession gameSession)
    {
        _context.GameSessions.Add(gameSession);
        await _context.SaveChangesAsync();
        return gameSession;
    }

    public async Task<GameSession> UpdateGameSession(GameSession gameSession)
    {
        var existingGameSession = await _context.GameSessions.FindAsync(gameSession.Id);
        if (existingGameSession == null)
            return null;

        existingGameSession.IsActive = gameSession.IsActive;
        await _context.SaveChangesAsync();

        return existingGameSession;
    }

    public async Task<bool> DeleteGameSession(int id)
    {
        var gameSession = await _context.GameSessions.FindAsync(id);
        if (gameSession == null) return false;

        _context.GameSessions.Remove(gameSession);
        await _context.SaveChangesAsync();
        return true;
    }
}