using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SigmaSharp.Stern.Module.UserStorage
{
    [Authorize]
    [Route("user-storage")]
    public class UserStorageController : Controller
    {
        [HttpGet]
        public async Task<string> GetValue()
        {
            return User.Identity.Name;
        }
    }
}
