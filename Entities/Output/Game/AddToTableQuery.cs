namespace Entities.Output.Game
{
    public class AddToTableQuery : BaseQuery
    {
        public string? Id { get; set; }
        public bool? IsAdded { get; set; }
        public List<Player>? Players { get; set; }
        public Player? Player { get; set; }
    }
}
