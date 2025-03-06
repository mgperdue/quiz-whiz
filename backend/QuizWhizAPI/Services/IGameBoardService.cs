#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IGameBoardService
{
    Task<IEnumerable<GameBoard>> GetAllGameBoards();
    Task<GameBoard> GetGameBoardById(int id);
    Task<GameBoard> CreateGameBoard(GameBoard gameBoard);
}