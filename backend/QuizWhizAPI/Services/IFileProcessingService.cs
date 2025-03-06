#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IFileProcessingService
{
    Task<FileProcessingResult> ProcessFile(IFormFile file);
}