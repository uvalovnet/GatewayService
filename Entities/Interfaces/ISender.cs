
using Entities.Requests.Account;
using Entities.Requests.Game;
using Entities.Requests.Pay;

namespace Entities.Interfaces
{
    public interface ISender
    {
        Task SendRegAndAuthAsync(RegAndAuthRequest accountData);
        Task SendGameAsync(GameActionRequest action);
        Task SendGameAsync(BillActionRequest action);
    }
}
