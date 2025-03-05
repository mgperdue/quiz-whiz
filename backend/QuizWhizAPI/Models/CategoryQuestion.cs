namespace QuizWhizAPI.Models;

public class CategoryQuestion
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int PointValue { get; set; }
}