using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SigmaSharp.Stern.Web.Models.Authentication;

namespace SigmaSharp.Stern.Web.Persistance
{
    public class CoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public CoreDbContext(DbContextOptions options)
            : base(options) { }
    }
}
