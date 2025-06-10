namespace Entities
{
    public class BaseDTO
    {
        public string? ConnectionId { get; set; }
        public string? GroupName { get; set; }
        public BaseDTO(string? connectionId, string? groupName)
        {
            ConnectionId = connectionId;
            GroupName = groupName;
        }
        public BaseDTO()
        {
            
        }
    }
}
