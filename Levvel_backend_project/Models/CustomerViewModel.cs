using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public ICollection<AddTruckResource> Favorites { get; set; }
    }
}
