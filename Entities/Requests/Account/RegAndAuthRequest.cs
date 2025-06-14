namespace Entities.Requests.Account
{
    public class RegAndAuthRequest : BaseDTO
    {
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? RefId { get; set; }

        public RegAndAuthRequest(string? nickName, string? email, string password,
            string? refId, string? ConnectionId, string? groupName) : base(ConnectionId, groupName)
        {
            NickName = nickName;
            Email = email;
            Password = password;
            RefId = refId;
        }
    }
}
