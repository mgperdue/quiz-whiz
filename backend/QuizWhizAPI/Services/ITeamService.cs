#region

using QuizWhizAPI.Models;

#endregion

namespace QuizWhizAPI.Services;

public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeams();
    Task<Team> GetTeamById(int id);
    Task<Team> CreateTeam(Team team);
    Task<bool> DeleteTeam(int id);
}