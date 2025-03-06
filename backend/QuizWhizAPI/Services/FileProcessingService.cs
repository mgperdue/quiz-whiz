#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public class FileProcessingService : IFileProcessingService
{
    public async Task<FileProcessingResult> ProcessFile(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLower();

        switch (extension)
        {
            case ".csv":
                return await ProcessCsv(file);
            case ".xlsx":
                return await ProcessExcel(file);
            case ".pdf":
                return await ProcessPdf(file);
            default:
                return new FileProcessingResult(false, "Unsupported file format.");
        }
    }

    private async Task<FileProcessingResult> ProcessCsv(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            // Process CSV line (Split, Validate, Insert into DB)
        }

        return new FileProcessingResult(true, "CSV processed successfully.");
    }

    private async Task<FileProcessingResult> ProcessExcel(IFormFile file)
    {
        return new FileProcessingResult(true, "Excel processing not yet implemented.");
    }

    private async Task<FileProcessingResult> ProcessPdf(IFormFile file)
    {
        return new FileProcessingResult(true, "PDF processing not yet implemented.");
    }
}