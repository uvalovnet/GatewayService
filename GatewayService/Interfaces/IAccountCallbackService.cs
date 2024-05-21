using Entities.Queries.Account;
using GatewayService.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GatewayService.Interfaces
{
    public interface IAccountCallbackService
    {
        Task Starter();
        Task Authentication(AuthenticateQuery data);
        Task Registration(RegistrationQuery data);
    }
}
