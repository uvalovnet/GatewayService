using Entities.Responses.Account;
using GatewayService.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GatewayService.Interfaces
{
    public interface IAccountCallbackService
    {
        Task Starter();
        Task Authentication(AuthenticateResponse data);
        Task Registration(RegistrationResponse data);
    }
}
