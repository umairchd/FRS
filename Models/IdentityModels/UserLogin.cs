namespace FRS.Models.IdentityModels
{
    /// <summary>
    /// User Logins
    /// </summary>
    public class UserLogin
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
