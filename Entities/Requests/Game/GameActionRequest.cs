namespace Entities.Requests.Game
{
    public class GameActionRequest : BaseDTO
    {
        public string? NickName { get; set; }
        public string? Action { get; set; }
        public string? Details { get; set; }
        public GameActionRequest(string? nickName, string? action, string? details,
            string? ConnectionId, string? groupName) : base(ConnectionId, groupName)
        {
            NickName = nickName;
            Action = action;
            Details = details;
        }
    }
}
