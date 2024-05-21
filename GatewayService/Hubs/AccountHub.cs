using Entities.Commands.Account;
using Entities.Interfaces;
using GatewayService.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GatewayService.Hubs
{
    public class AccountHub : Hub
    {
        ISender _sender;
        IAccountCallbackService _callbackService;
        public AccountHub(ISender sender)
        {
            _sender = sender;  
        }

        public async Task SignInAsync(RegAndAuthCommand data)
        {
            try
            {
                data.IsReg = false;
                data.ConnectionId = Context.ConnectionId;
                await _sender.SendRegAndAuthAsync(data);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }

        public async Task SignUpAsync(RegAndAuthCommand data)
        {
            try
            {
                data.IsReg = true;
                data.ConnectionId = Context.ConnectionId;
                await _sender.SendRegAndAuthAsync(data);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
    }
}
