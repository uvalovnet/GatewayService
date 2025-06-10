namespace Entities.Requests.Pay
{
    public class BillActionRequest : BaseDTO
    {
        public string? BillType { get; set; }
        public string? BillNumber { get; set; }
        public string? Action { get; set; }
        public string? Price { get; set; }
        public string? To { get; set; }
        public BillActionRequest(string? connectionId, string? groupName) : base(connectionId, groupName)
        {

        }
    }
}
