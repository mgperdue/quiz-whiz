using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public class BuzzerRepository : IBuzzerRepository
{
    private readonly AppDbContext _context;

    public BuzzerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BuzzerEntry>> GetAllBuzzEntries()
    {
        return await _context.BuzzerEntries.OrderBy(b => b.Timestamp).ToListAsync();
    }

    public async Task<BuzzerEntry> GetFirstBuzzEntry()
    {
        return await _context.BuzzerEntries.OrderBy(b => b.Timestamp).FirstOrDefaultAsync();
    }

    public async Task AddBuzzEntry(BuzzerEntry buzzerEntry)
    {
        _context.BuzzerEntries.Add(buzzerEntry);
        await _context.SaveChangesAsync();
    }

    public async Task ClearBuzzQueue()
    {
        _context.BuzzerEntries.RemoveRange(_context.BuzzerEntries);
        await _context.SaveChangesAsync();
    }
}