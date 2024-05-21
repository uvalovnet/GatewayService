using Entities.Interfaces;
using Entities.Queries.Game;
using GatewayService.Hubs;
using GatewayService.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GatewayService.Services
{
    public class GameCallbackService : IGameCallbackService
    {
        ICallbackSeparator _separator;
        IHubContext<GameHub> _hub;

        public GameCallbackService(ICallbackSeparator separator, IHubContext<GameHub> hubContext)
        {
            _separator = separator;
            _hub = hubContext;
        }
        public async Task Starter()
        {
            _separator.Sub(GetGames);
            _separator.Sub(AddToTable);
            _separator.Sub(RemoveFromTable);
            _separator.Sub(TakeAction);
        }

        public async Task GetGames(GetGamesQuery separatedData)
        {
            _hub.Clients.Client(separatedData.ConnectionId).SendAsync("GameList", separatedData.Games);
        }
        public async Task AddToTable(AddToTableQuery separatedData)
        {
            if ((bool)separatedData.IsAdded)
            {
                _hub.Groups.AddToGroupAsync(separatedData.ConnectionId, separatedData.GroupName);
                _hub.Clients.Client(separatedData.ConnectionId).SendAsync("AddToTable", separatedData.Players);
                _hub.Clients.Group(separatedData.GroupName).SendAsync("AddPlayer", separatedData.Player);
            }
        }
        public async Task RemoveFromTable(RemoveFromTableQuery separatedData)
        {
            _hub.Groups.RemoveFromGroupAsync(separatedData.ConnectionId, separatedData.GroupName);
            _hub.Clients.Client(separatedData.ConnectionId).SendAsync("RemoveFromTable", separatedData.RemovedUsersId);
            _hub.Clients.Group(separatedData.GroupName).SendAsync("AddPlayer", separatedData.Player);
        }
        public async Task TakeAction(PlayerActionQuery separatedData)
        {
            _hub.Clients.Group(separatedData.GroupName).SendAsync("TakeAction", separatedData);
        }
    }
}
