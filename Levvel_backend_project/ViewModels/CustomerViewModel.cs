using System;
using System.Collections.Generic;

namespace Levvel_backend_project.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public ICollection<TruckViewModel> Favorites { get; set; }
    }
}
