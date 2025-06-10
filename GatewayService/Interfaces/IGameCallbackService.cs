using Entities.Responses.Game;

namespace GatewayService.Interfaces
{
    public interface IGameCallbackService
    {
        Task Starter();
        Task GetGames(GetGamesResponse separatedData);
        Task AddToTable(AddToTableResponse separatedData);
        Task RemoveFromTable(RemoveFromTableResponse separatedData);
        Task TakeAction(PlayerActionResponse separatedData);
    }
}
