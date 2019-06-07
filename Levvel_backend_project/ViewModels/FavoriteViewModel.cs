using System.ComponentModel.DataAnnotations;

namespace Levvel_backend_project.ViewModels
{
    public class FavoriteViewModel
    {
        [Required]
        public int TruckId { get; set; }
    }
}
