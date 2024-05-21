using Entities.Output.Account;
using Entities.Output.Game;

namespace Entities.Interfaces
{
    public interface ICallbackSeparator
    {
        delegate Task AuthenticationDelegate(AuthenticateQuery receivedData);
        delegate Task RegistrationDelegate(RegistrationQuery receivedData);
        delegate Task GetGamesDelegate(GetGamesQuery receivedData);
        delegate Task AddToTableDelegate(AddToTableQuery receivedData);
        delegate Task RemoveFromTableDelegate(RemoveFromTableQuery receivedData);
        delegate Task TakeActionDelegate(PlayerActionQuery receivedData);

        Task Subscribe();
        Task Sub(AuthenticationDelegate method);
        Task Sub(RegistrationDelegate method);
        Task Sub(GetGamesDelegate method);
        Task Sub(AddToTableDelegate method);
        Task Sub(RemoveFromTableDelegate method);
        Task Sub(TakeActionDelegate method);
    }
}
