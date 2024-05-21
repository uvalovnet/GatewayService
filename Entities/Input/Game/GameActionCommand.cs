namespace Entities.Input
{
    public class GameActionCommand : BaseCommand
    {
        public string? NickName { get; set; }
        public string? Action { get; set; }
        public string? Details { get; set; }
        public GameActionCommand(string? nickName, string? action, string? details,
            string? ConnectionId, string? groupName) : base(ConnectionId, groupName)
        {
            NickName = nickName;
            Action = action;
            Details = details;
        }
    }
}
