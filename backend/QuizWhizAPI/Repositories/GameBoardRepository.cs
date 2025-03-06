using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public class GameBoardRepository : IGameBoardRepository
{
    private readonly AppDbContext _context;

    public GameBoardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameBoard>> GetAllGameBoards()
    {
        return await _context.GameBoards.Include(gb => gb.Categories).ToListAsync();
    }

    public async Task<GameBoard> GetGameBoardById(int id)
    {
        return await _context.GameBoards
            .Include(gb => gb.Categories)
            .FirstOrDefaultAsync(gb => gb.Id == id);
    }

    public async Task<GameBoard> CreateGameBoard(GameBoard gameBoard)
    {
        _context.GameBoards.Add(gameBoard);
        await _context.SaveChangesAsync();
        return gameBoard;
    }

    public async Task<GameBoard> UpdateGameBoard(GameBoard gameBoard)
    {
        var existingGameBoard = await _context.GameBoards.FindAsync(gameBoard.Id);
        if (existingGameBoard == null)
            return null;

        existingGameBoard.Name = gameBoard.Name;
        existingGameBoard.PointValues = gameBoard.PointValues;
        await _context.SaveChangesAsync();

        return existingGameBoard;
    }

    public async Task<bool> DeleteGameBoard(int id)
    {
        var gameBoard = await _context.GameBoards.FindAsync(id);
        if (gameBoard == null) return false;

        _context.GameBoards.Remove(gameBoard);
        await _context.SaveChangesAsync();
        return true;
    }
}