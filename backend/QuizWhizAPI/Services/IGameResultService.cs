#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IGameResultService
{
    Task<IEnumerable<GameResult>> GetAllGameResults();
    Task<GameResult> GetGameResultById(int id);
    Task<GameResult> SaveGameResult(GameResult gameResult);
}