using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TruckCategory> TruckCategory { get; set; }
    }
}
