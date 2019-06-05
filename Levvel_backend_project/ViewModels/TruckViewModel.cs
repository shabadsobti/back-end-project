using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Levvel_backend_project.Models;

namespace Levvel_backend_project.ViewModels
{
    public class TruckViewModel
    {
        public int TruckId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        // \${1,4}
        [RegularExpression("^(\\${1,4})$", ErrorMessage = "Price needs to be between $ and $$$$")]
        public string Price { get; set; }
        [Range(1, 5)]
        public decimal Rating { get; set; }
        [Required]
        public string Hours { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public Coordinates Coordinates { get; set; }
        [Required]
        public Address Location { get; set; }


        public List<CategoryViewModel> Categories { get; set; }
       

    }
}
