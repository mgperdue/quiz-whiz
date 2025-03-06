using QuizWhizAPI.Models;

namespace QuizWhizAPI.Repositories;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeams();
    Task<Team> GetTeamById(int id);
    Task<Team> CreateTeam(Team team);
    Task<Team> UpdateTeam(Team team);
    Task<bool> DeleteTeam(int id);
    Task AssignPlayerToTeam(int playerId, int teamId);
    Task RemovePlayerFromTeam(int playerId);
}