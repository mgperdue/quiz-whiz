#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class GameBoardService : IGameBoardService
{
    private readonly AppDbContext _context;

    public GameBoardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameBoard>> GetAllGameBoards()
    {
        return await _context.GameBoards.Include(gb => gb.Categories).ToListAsync();
    }

    public async Task<GameBoard> CreateGameBoard(GameBoard gameBoard)
    {
        _context.GameBoards.Add(gameBoard);
        await _context.SaveChangesAsync();
        return gameBoard;
    }
}