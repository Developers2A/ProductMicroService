using Microsoft.AspNetCore.Identity;

namespace Product.Domain.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
