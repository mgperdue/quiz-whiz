#region

using Microsoft.AspNetCore.SignalR;

#endregion

namespace QuizWhizAPI.Hubs;

public class LobbyHub : Hub
{
    public async Task PlayerJoined(int gameId, string playerName, int teamId)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ReceivePlayerJoined", playerName, teamId);
    }

    public async Task PlayerLeft(int gameId, string playerName)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ReceivePlayerLeft", playerName);
    }

    public async Task JoinLobby(int gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"game-{gameId}");
    }
}