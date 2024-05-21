namespace Entities.Output.Account
{
    public class AuthenticateQuery : BaseQuery
    {
        public User? User { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
