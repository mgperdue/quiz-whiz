namespace QuizWhizAPI.Models;

public class BuzzerEntry
{
    public int Id { get; set; }
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    public DateTime Timestamp { get; set; }
}