#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IBuzzerService
{
    Task<BuzzerEntry> RegisterBuzz(int sessionId, int teamId, int playerId);
    Task<IEnumerable<BuzzerEntry>> GetBuzzerQueue(int sessionId);
    Task<bool> ClearQueue(int sessionId);
}