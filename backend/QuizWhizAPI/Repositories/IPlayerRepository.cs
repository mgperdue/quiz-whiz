using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetAllPlayers();
    Task<Player> GetPlayerById(int id);
    Task<Player> CreatePlayer(Player player);
    Task<bool> DeletePlayer(int id);
}