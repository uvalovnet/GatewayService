namespace Entities.Responses.Game
{
    public class RemoveFromTableResponse : BaseDTO
    {
        public string? Id { get; set; }
        public string? RemovedUsersId { get; set; }
        public Player? Player { get; set; }
    }
}
