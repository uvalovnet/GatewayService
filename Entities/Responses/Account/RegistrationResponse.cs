namespace Entities.Responses.Account
{
    public class RegistrationResponse : BaseDTO
    {
        public User? User { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
