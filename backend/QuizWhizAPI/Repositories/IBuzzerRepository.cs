using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IBuzzerRepository
{
    Task<IEnumerable<BuzzerEntry>> GetAllBuzzEntries();
    Task<BuzzerEntry> GetFirstBuzzEntry();
    Task AddBuzzEntry(BuzzerEntry buzzerEntry);
    Task ClearBuzzQueue();
}