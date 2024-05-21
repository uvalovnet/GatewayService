namespace Entities.Input
{
    public class BaseCommand
    {
        public string? ConnectionId { get; set; }
        public string? GroupName { get; set; }
        public BaseCommand(string? connectionId, string? groupName)
        {
            ConnectionId = connectionId;
            GroupName = groupName;
        }
    }
}
