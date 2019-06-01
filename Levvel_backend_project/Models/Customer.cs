using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }  // navigation property

        public ICollection<CustomerTrucks> Favorites { get; set; }
    }
}
