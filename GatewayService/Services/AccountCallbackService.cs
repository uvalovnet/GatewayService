using Entities.Interfaces;
using Entities.Responses.Account;
using GatewayService.Hubs;
using GatewayService.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace GatewayService.Services
{
    public class AccountCallbackService : IAccountCallbackService
    {
        ICallbackSeparator _separator;
        IHubContext<AccountHub> _hub;
        public AccountCallbackService(ICallbackSeparator separator, IHubContext<AccountHub> hubContext)
        {
            _separator = separator;
            _hub = hubContext;
        }
        public async Task Starter()
        {
            _separator.Sub(Authentication);
            _separator.Sub(Registration);
        }
        public async Task Authentication(AuthenticateResponse data)
        {
            try
            {
                if(data.User == null)
                {
                    _hub.Clients.Client(data.ConnectionId).SendAsync("AuthError", data.ErrorDescription);
                }
                else if ((bool)data.User.IsLogInGranted)
                {
                    _hub.Clients.Client(data.ConnectionId).SendAsync("Auth", data.User);
                }
                else
                {
                    _hub.Clients.Client(data.ConnectionId).SendAsync("AuthError", data.ErrorDescription);
                }
            }
            catch(Exception ex)
            {
                //ВВЕСТИ ЛОГГЕР
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task Registration(RegistrationResponse data)
        {
            try
            {
                if (data.IsSuccess)
                {
                    _hub.Clients.Client(data.ConnectionId).SendAsync("Success", data);
                }
                else
                {
                    _hub.Clients.Client(data.ConnectionId).SendAsync("RegError", data.ErrorDescription);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
