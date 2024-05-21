namespace Entities.Output.Game
{
    public class RemoveFromTableQuery : BaseQuery
    {
        public string? Id { get; set; }
        public string? RemovedUsersId { get; set; }
        public Player? Player { get; set; }
    }
}
