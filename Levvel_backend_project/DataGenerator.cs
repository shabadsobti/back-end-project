using System;
using System.Linq;
using Levvel_backend_project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Levvel_backend_project
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                // Look for any board games.
                if (context.Trucks.Any())
                {
                    return;   // Data was already seeded
                }


                var truck1 = new Truck
                {
                    TruckId = 1,
                    Title = "Candy Land",
                    Location = new Address
                    {
                        Street = "852 West Main", 
                        City = "Cville",
                        State = "VA",
                        Country = "USA",
                        Zip = "22903"

                    }
                };


                context.Trucks.AddRange(truck1);

                var cat2 = new Category
                {
                    CategoryId = 1,
                    CategoryName = "southen"
                };

                var cat1 = new Category
                {
                    CategoryId = 2,
                    CategoryName = "Chineese"
                };

                context.Categories.Add(cat2);

                context.TruckCategories.Add(new TruckCategory
                {
                    CategoryId = 1,
                    Truck = truck1,
                    Category = cat2,
                    TruckId = 1
                });


                context.TruckCategories.Add(new TruckCategory
                {
                  
                    Truck = truck1,
                    Category = cat1,
                });


                context.SaveChanges();
            }
        }
    }
}