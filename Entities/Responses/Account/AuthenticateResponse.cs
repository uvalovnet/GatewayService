namespace Entities.Responses.Account
{
    public class AuthenticateResponse : BaseDTO
    {
        public User? User { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
