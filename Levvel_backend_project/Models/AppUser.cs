using System;


namespace Levvel_backend_project.Models
{
    public class AppUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
