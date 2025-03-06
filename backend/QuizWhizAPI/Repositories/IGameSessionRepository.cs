using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IGameSessionRepository
{
    Task<IEnumerable<GameSession>> GetAllGameSessions();
    Task<GameSession> GetGameSessionById(int id);
    Task<GameSession> CreateGameSession(GameSession gameSession);
    Task<GameSession> UpdateGameSession(GameSession gameSession);
    Task<bool> DeleteGameSession(int id);
}