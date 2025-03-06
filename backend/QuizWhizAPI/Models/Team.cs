namespace QuizWhizAPI.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Color { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<Player> Players { get; set; }
    public int Score { get; set; }
}