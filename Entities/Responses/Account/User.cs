namespace Entities.Responses.Account
{
    public class User
    {
        //Contains players nickname. may using in different responses
        public string? NickName { get; set; }

        //Contains response data on auth
        public bool? IsLogInGranted { get; set; }
        public decimal? WalletCash { get; set; }

        public bool? IsRegistered { get; set; }
        public User(User user)
        {
            NickName = user.NickName;
            IsLogInGranted = user.IsLogInGranted;
            WalletCash = user.WalletCash;
            IsRegistered = user.IsRegistered;
        }
    }
}
