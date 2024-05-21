namespace Entities.Output.Account
{
    public class RegistrationQuery : BaseQuery
    {
        public User? User { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
