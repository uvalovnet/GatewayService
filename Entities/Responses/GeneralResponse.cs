using Entities.Responses.Account;
using Entities.Responses.Game;

namespace Entities.Responses
{
    public class GeneralResponse
    {
        public AuthenticateResponse? Authentication { get; set; }

        public RegistrationResponse? Registration { get; set; }

        public AddToTableResponse? AddToTable { get; set; }

        public RemoveFromTableResponse? RemoveFromTable { get; set; }

        public GetGamesResponse? GetGames { get; set; }

        public PlayerActionResponse? PlayerAction { get; set; }

        //Contains operation type for separator works
        public OperationTypes OperationType { get; set; }
        public string? Details { get; set; }

    }
}
