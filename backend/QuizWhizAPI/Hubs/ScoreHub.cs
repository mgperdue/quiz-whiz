#region

using Microsoft.AspNetCore.SignalR;

#endregion

namespace QuizWhizAPI.Hubs;

public class ScoreHub : Hub
{
    public async Task UpdateScore(int gameId, int teamId, int newScore)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ReceiveScoreUpdate", teamId, newScore);
    }

    public async Task JoinGame(int gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"game-{gameId}");
    }
}