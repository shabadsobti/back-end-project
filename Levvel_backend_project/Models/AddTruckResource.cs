using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Levvel_backend_project.Models
{
    public class AddTruckResource
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


        public List<CategoryResource> Categories { get; set; }

    }
}
