#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/file-upload")]
[ApiController]
public class FileUploadController : ControllerBase
{
    private readonly IFileProcessingService _fileProcessingService;

    public FileUploadController(IFileProcessingService fileProcessingService)
    {
        _fileProcessingService = fileProcessingService;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file was uploaded.");

        var result = await _fileProcessingService.ProcessFile(file);
        return result.Success ? Ok(result) : BadRequest(result.Message);
    }
}