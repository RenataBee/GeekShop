using Microsoft.AspNetCore.Identity;

namespace Geek.IdentityServer.ModelDB.Context
{
    public class ApplicationUser : IdentityUser
    {
        private string FirstName { get; set; }  = string.Empty;
        private string LastName { get; set; } = string.Empty;
    }
}
