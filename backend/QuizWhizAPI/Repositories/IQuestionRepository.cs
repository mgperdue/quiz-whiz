#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllQuestions();
    Task<Question> GetQuestionById(int id);
    Task<Question> CreateQuestion(Question question);
    Task<bool> DeleteQuestion(int id);
}