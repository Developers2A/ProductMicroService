using Microsoft.AspNetCore.Identity;

namespace ProductService.Domain.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
