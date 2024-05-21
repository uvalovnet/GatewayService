using Entities.Commands.Game;
using Entities.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GatewayService.Hubs
{
    public class GameHub : Hub
    {
        ISender _sender;
        public GameHub(ISender sender)
        {
            _sender = sender;
        }


        public async Task GetGameList()
        {
            try
            {
                await _sender.SendGameAsync(new GameActionCommand(null, "GetGames", null, Context.ConnectionId, null));
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
        public async Task AddToTable(GameActionCommand action)
        {
            try
            {
                action.ConnectionId = Context.ConnectionId;
                await _sender.SendGameAsync(action);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
        public async Task RemoveFromTable(GameActionCommand action)
        {
            try
            {
                action.ConnectionId = Context.ConnectionId;
                await _sender.SendGameAsync(action);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }

        public async Task TakeAction(GameActionCommand action)
        {
            try
            {
                action.ConnectionId = Context.ConnectionId;
                await _sender.SendGameAsync(action);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
    }
}
