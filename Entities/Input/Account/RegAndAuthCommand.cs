namespace Entities.Input.Account
{
    public class RegAndAuthCommand : BaseCommand
    {
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? RefId { get; set; }
        public bool? IsReg { get; set; }

        public RegAndAuthCommand(string? nickName, string? email, string password,
            string? refId, bool? isReg, string? ConnectionId, string? groupName) : base(ConnectionId, groupName)
        {
            NickName = nickName;
            Email = email;
            Password = password;
            RefId = refId;
            IsReg = isReg;
        }
    }
}
