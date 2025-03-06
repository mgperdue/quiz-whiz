using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IGameBoardRepository
{
    Task<IEnumerable<GameBoard>> GetAllGameBoards();
    Task<GameBoard> GetGameBoardById(int id);
    Task<GameBoard> CreateGameBoard(GameBoard gameBoard);
    Task<GameBoard> UpdateGameBoard(GameBoard gameBoard);
    Task<bool> DeleteGameBoard(int id);
}