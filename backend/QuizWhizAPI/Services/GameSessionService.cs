#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class GameSessionService : IGameSessionService
{
    private readonly AppDbContext _context;

    public GameSessionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GameSession> StartGameSession(int gameBoardId)
    {
        var gameBoard = await _context.GameBoards.FindAsync(gameBoardId);
        if (gameBoard == null) throw new Exception("Game board not found.");

        var session = new GameSession
        {
            GameBoardId = gameBoardId,
            StartTime = DateTime.UtcNow,
            IsActive = true
        };

        _context.GameSessions.Add(session);
        await _context.SaveChangesAsync();
        return session;
    }

    public async Task<bool> EndGameSession(int sessionId)
    {
        var session = await _context.GameSessions.FindAsync(sessionId);
        if (session == null) return false;

        session.IsActive = false;
        session.EndTime = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GameSession> GetGameSessionById(int sessionId)
    {
        return await _context.GameSessions
            .Include(gs => gs.Teams)
            .FirstOrDefaultAsync(gs => gs.Id == sessionId);
    }
}