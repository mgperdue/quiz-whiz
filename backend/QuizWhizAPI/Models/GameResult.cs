namespace QuizWhizAPI.Models;

public class GameResult
{
    public int Id { get; set; }
    public int GameSessionId { get; set; }
    public GameSession GameSession { get; set; }
    public ICollection<Team> FinalTeamRankings { get; set; }
}