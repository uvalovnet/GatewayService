using Entities.Responses.Account;
using Entities.Responses.Game;

namespace Entities.Interfaces
{
    public interface ICallbackSeparator
    {
        delegate Task AuthenticationDelegate(AuthenticateResponse receivedData);
        delegate Task RegistrationDelegate(RegistrationResponse receivedData);
        delegate Task GetGamesDelegate(GetGamesResponse receivedData);
        delegate Task AddToTableDelegate(AddToTableResponse receivedData);
        delegate Task RemoveFromTableDelegate(RemoveFromTableResponse receivedData);
        delegate Task TakeActionDelegate(PlayerActionResponse receivedData);

        Task Subscribe();
        Task Sub(AuthenticationDelegate method);
        Task Sub(RegistrationDelegate method);
        Task Sub(GetGamesDelegate method);
        Task Sub(AddToTableDelegate method);
        Task Sub(RemoveFromTableDelegate method);
        Task Sub(TakeActionDelegate method);
    }
}
