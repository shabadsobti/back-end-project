using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TruckCategory> TruckCategory { get; set; }
    }
}
