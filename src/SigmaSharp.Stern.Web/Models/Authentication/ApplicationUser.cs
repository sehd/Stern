using Microsoft.AspNetCore.Identity;

namespace SigmaSharp.Stern.Web.Models.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
