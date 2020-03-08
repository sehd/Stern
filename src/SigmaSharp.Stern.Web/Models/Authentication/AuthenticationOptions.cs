namespace SigmaSharp.Stern.Web.Models.Authentication
{
    public class AuthenticationOptions
    {
        public bool ShouldValidateIssuer { get; set; }
        public bool ShouldValidateAudience { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
    }
}
