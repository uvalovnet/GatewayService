using Entities.Output.Account;
using Entities.Output.Game;

namespace Entities.Output
{
    public class GeneralQuery
    {
        public AuthenticateQuery? Authentication { get; set; }

        public RegistrationQuery? Registration { get; set; }

        public AddToTableQuery? AddToTable { get; set; }

        public RemoveFromTableQuery? RemoveFromTable { get; set; }

        public GetGamesQuery? GetGames { get; set; }

        public PlayerActionQuery? PlayerAction { get; set; }

        //Contains operation type for separator works
        public string? OperationType { get; set; }
        public string? Details { get; set; }

    }
}
