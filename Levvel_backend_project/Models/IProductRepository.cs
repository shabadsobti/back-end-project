using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public class IProductRepository
    {
        private List<Truck> trucks = new List<Truck>();


        public IProductRepository()
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }


    }
}
