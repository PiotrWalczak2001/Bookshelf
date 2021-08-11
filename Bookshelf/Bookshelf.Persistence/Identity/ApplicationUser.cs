using Microsoft.AspNetCore.Identity;

namespace Bookshelf.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
