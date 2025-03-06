#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetAllQuestions()
    {
        return await _context.Questions.Include(q => q.Hints).ToListAsync();
    }

    public async Task<Question> GetQuestionById(int id)
    {
        return await _context.Questions
            .Include(q => q.Hints)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Question> CreateQuestion(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task<bool> DeleteQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null) return false;

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return true;
    }
}