using Entities.Commands.Account;
using Entities.Commands.Game;
using Entities.Commands.Pay;

namespace Entities.Interfaces
{
    public interface ISender
    {
        Task SendRegAndAuthAsync(RegAndAuthCommand accountData);
        Task SendGameAsync(GameActionCommand action);
        Task SendGameAsync(BillActionCommand action);
    }
}
