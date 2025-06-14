namespace Entities.Responses.Account
{
    public class RegistrationResponse : BaseDTO
    {
        public bool IsSuccess { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
