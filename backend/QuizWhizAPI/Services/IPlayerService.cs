#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayers();
    Task<Player> GetPlayerById(int id);
    Task<Player> CreatePlayer(Player player);
    Task<bool> DeletePlayer(int id);
}