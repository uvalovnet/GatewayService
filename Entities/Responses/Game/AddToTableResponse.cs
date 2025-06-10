namespace Entities.Responses.Game
{
    public class AddToTableResponse : BaseDTO
    {
        public string? Id { get; set; }
        public bool? IsAdded { get; set; }
        public List<Player>? Players { get; set; }
        public Player? Player { get; set; }
    }
}
