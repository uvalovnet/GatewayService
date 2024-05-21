namespace Entities.Output
{
    public class BaseQuery
    {
        public string? ConnectionId { get; set; }
        public string? GroupName { get; set; }
        public BaseQuery(string? connectionId, string? groupName)
        {
            ConnectionId = connectionId;
            GroupName = groupName;
        }
        public BaseQuery()
        {

        }

    }
}
