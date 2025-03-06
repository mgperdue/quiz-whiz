namespace QuizWhizAPI.Models;

public class GameSession
{
    public int Id { get; set; }
    public int GameBoardId { get; set; }
    public GameBoard GameBoard { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public ICollection<Team> Teams { get; set; }
    public ICollection<BuzzerEntry> BuzzerEntries { get; set; }
}