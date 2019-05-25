using System;
namespace Levvel_backend_project.Models
{
    public class TruckCategory
    {
        public int TruckId { get; set; }
        public Truck Truck { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
