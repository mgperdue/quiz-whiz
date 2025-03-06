namespace QuizWhizAPI.Models;

public class GameBoard
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Category> Categories { get; set; }
    public List<int> PointValues { get; set; } // Each row has the same point values across categories
}