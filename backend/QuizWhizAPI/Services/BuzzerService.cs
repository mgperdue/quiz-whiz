#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class BuzzerService : IBuzzerService
{
    private readonly AppDbContext _context;

    public BuzzerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BuzzerEntry> RegisterBuzz(int sessionId, int teamId, int playerId)
    {
        var session = await _context.GameSessions.FindAsync(sessionId);
        if (session == null || !session.IsActive) throw new Exception("Invalid or inactive session.");

        var buzzerEntry = new BuzzerEntry
        {
            GameSessionId = sessionId,
            TeamId = teamId,
            PlayerId = playerId,
            Timestamp = DateTime.UtcNow
        };

        _context.BuzzerEntries.Add(buzzerEntry);
        await _context.SaveChangesAsync();

        return buzzerEntry;
    }

    public async Task<IEnumerable<BuzzerEntry>> GetBuzzerQueue(int sessionId)
    {
        return await _context.BuzzerEntries
            .Where(b => b.GameSessionId == sessionId)
            .OrderBy(b => b.Timestamp)
            .ToListAsync();
    }

    public async Task<bool> ClearQueue(int sessionId)
    {
        var entries = await _context.BuzzerEntries.Where(b => b.GameSessionId == sessionId).ToListAsync();
        if (!entries.Any()) return false;

        _context.BuzzerEntries.RemoveRange(entries);
        await _context.SaveChangesAsync();
        return true;
    }
}