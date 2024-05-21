using Entities.Queries.Game;

namespace GatewayService.Interfaces
{
    public interface IGameCallbackService
    {
        Task Starter();
        Task GetGames(GetGamesQuery separatedData);
        Task AddToTable(AddToTableQuery separatedData);
        Task RemoveFromTable(RemoveFromTableQuery separatedData);
        Task TakeAction(PlayerActionQuery separatedData);
    }
}
