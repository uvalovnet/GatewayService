using Entities.Requests.Game;
using Entities.Interfaces;
using Entities.Requests.Game;
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
                await _sender.SendGameAsync(new GameActionRequest(null, "GetGames", null, Context.ConnectionId, null));
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
        public async Task AddToTable(GameActionRequest action)
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
        public async Task RemoveFromTable(GameActionRequest action)
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

        public async Task TakeAction(GameActionRequest action)
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
