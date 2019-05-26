using System;
using System.Collections.Generic;

namespace Levvel_backend_project.Models
{
    public interface ITruckRepository
    {
        IEnumerable<Truck> GetAll();
        Truck Get(int id);
        //Truck Add(Truck item);
        //void Remove(int id);
        //bool Update(Truck item);
    }
}
