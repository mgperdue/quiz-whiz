#region

using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuizWhizAPI.Controllers;

[Route("api/questions")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
    {
        var questions = await _questionService.GetAllQuestions();
        return Ok(questions);
    }

    [HttpPost]
    public async Task<ActionResult<Question>> CreateQuestion([FromBody] Question question)
    {
        var createdQuestion = await _questionService.CreateQuestion(question);
        return CreatedAtAction(nameof(GetAllQuestions), new { id = createdQuestion.Id }, createdQuestion);
    }
}