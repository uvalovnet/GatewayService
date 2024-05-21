namespace Entities.Input.Pay
{
    public class BillActionCommand : BaseCommand
    {
        public string? BillType { get; set; }
        public string? BillNumber { get; set; }
        public string? Action { get; set; }
        public string? Price { get; set; }
        public string? To { get; set; }
        public BillActionCommand(string? connectionId, string? groupName) : base(connectionId, groupName)
        {

        }
    }
}
