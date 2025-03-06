#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetAllQuestions();
    Task<Question> GetQuestionById(int id);
    Task<Question> CreateQuestion(Question question);
    Task<bool> DeleteQuestion(int id);
}