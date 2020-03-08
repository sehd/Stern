using System.ComponentModel.DataAnnotations;

namespace SigmaSharp.Stern.Web.Models.Authentication
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
