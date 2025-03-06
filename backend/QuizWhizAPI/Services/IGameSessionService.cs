#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IGameSessionService
{
    Task<GameSession> StartGameSession(int gameBoardId);
    Task<bool> EndGameSession(int sessionId);
    Task<GameSession> GetGameSessionById(int sessionId);
}