using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SigmaSharp.Stern.Module.UserStorage
{
    [Route("user-storage")]
    public class UserStorageController : Controller
    {
        [HttpGet]
        public async Task<string> GetValue()
        {
            return "Hello";
        }
    }
}
