#region

using Microsoft.AspNetCore.SignalR;

#endregion

namespace QuizWhizAPI.Hubs;

public class BuzzerHub : Hub
{
    public async Task SendBuzz(int gameId, int teamId, int playerId)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ReceiveBuzz", teamId, playerId);
    }

    public async Task ClearBuzzQueue(int gameId)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ClearBuzzQueue");
    }

    public async Task JoinGame(int gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"game-{gameId}");
    }
}