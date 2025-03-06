using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IGameResultRepository
{
    Task<IEnumerable<GameResult>> GetAllGameResults();
    Task<GameResult> GetGameResultById(int id);
    Task<GameResult> SaveGameResult(GameResult gameResult);
}