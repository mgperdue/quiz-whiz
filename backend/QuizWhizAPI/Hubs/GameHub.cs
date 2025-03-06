#region

using Microsoft.AspNetCore.SignalR;

#endregion

namespace QuizWhizAPI.Hubs;

public class GameHub : Hub
{
    public async Task SendQuestionUpdate(int gameId, int questionId)
    {
        await Clients.Group($"game-{gameId}").SendAsync("ReceiveQuestionUpdate", questionId);
    }

    public async Task JoinGame(int gameId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"game-{gameId}");
    }
}