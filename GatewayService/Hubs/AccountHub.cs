using Entities.Requests.Account;
using Entities.Interfaces;
using GatewayService.Interfaces;
using Microsoft.AspNetCore.SignalR;
using GatewayService.Models;
using Entities.Requests;

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

        public async Task SignInAsync(RegAndAuthRequest data)
        {
            try
            {
                data.ConnectionId = Context.ConnectionId;
                //await _sender.SendRegAndAuthAsync(data);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }

        public async Task Reg(RegRequest request)
        {
            try
            {
                var data = new RegAndAuthRequest(
                    request.username,
                    request.email,
                    request.password,
                    null,
                    Context.ConnectionId,
                    null);
                await _sender.SendAsync(Topics.UserRegistration.ToString(), data);
            }
            catch
            {
                Clients.Caller.SendAsync("SomeError");
            }
        }
    }
}
