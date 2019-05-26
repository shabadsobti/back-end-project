using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Levvel_backend_project.Models
{
    public class Truck
    {
        public int TruckId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        [Range(1, 5)]
        public decimal Rating { get; set; }
        public string Hours { get; set; }
        public string Phone { get; set; }
        public Coordinates Coordinates { get; set; }
        public Address Location { get; set; }


        public virtual ICollection<TruckCategory> TruckCategory { get; set; }
    }

    [Owned]
    public class Coordinates
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }

    [Owned]
    public class Address
    { 
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}
