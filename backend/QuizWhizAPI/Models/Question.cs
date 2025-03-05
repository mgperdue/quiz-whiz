namespace QuizWhizAPI.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Answer { get; set; }
    public string? ImageUrl { get; set; }
    public string? VideoUrl { get; set; }
    public int ReadingTimeSeconds { get; set; }
    public ICollection<Hint>? Hints { get; set; }
}