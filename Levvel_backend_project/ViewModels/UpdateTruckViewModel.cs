using System.ComponentModel.DataAnnotations;
using Levvel_backend_project.Models;

namespace Levvel_backend_project.ViewModels
{
    public class UpdateTruckViewModel
    {
        [Required]
        public string Hours { get; set; }

        [Required]
        public Address Location { get; set; }

    }
}
