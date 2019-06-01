using System;
namespace Levvel_backend_project.Models
{
    public class CustomerTrucks
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}
