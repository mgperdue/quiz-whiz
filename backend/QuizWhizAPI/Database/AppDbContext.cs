#region

using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<GameBoard> GameBoards { get; set; }
    public DbSet<CategoryQuestion> CategoryQuestions { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<BuzzerEntry> BuzzerEntries { get; set; }
    public DbSet<GameResult> GameResults { get; set; }
    public DbSet<Hint> Hints { get; set; }
    public DbSet<ThemeSetting> ThemeSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define composite keys and relationships if needed
        modelBuilder.Entity<CategoryQuestion>()
            .HasKey(cq => new { cq.CategoryId, cq.QuestionId });

        modelBuilder.Entity<BuzzerEntry>()
            .HasIndex(b => new { b.GameSessionId, b.Timestamp });

        base.OnModelCreating(modelBuilder);
    }
}