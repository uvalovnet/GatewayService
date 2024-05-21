namespace Entities.Output.Game
{
    public class Player
    {
        public string? NickName { get; set; }
        public decimal? Cheaps { get; set; }

        //Contains action name in game process
        public string? Action { get; set; }

        //May contains error descriptions or details of action
        public string? Details { get; set; }

        public decimal? Qty { get; set; }
    }
}
