using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levvel_backend_project.Models;

namespace Levvel_backend_project.ViewModels
{
    public class TruckViewModel
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


        public List<CategoryViewModel> Categories { get; set; }
       

    }
}
