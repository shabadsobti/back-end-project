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
                    //TruckId = 1,
                    Title = "Candy Land",
                    Price = 1,
                    Rating = 3.4m,
                    Hours = "9:00,10:00,12:00,13:00",
                    Phone = "4344664943",
                    Coordinates = new Coordinates
                    {
                        Latitude = 123.90m,
                        Longitude = 143.20m
                    },
                    Location = new Address
                    {
                        Street = "852 West Main", 
                        City = "Cville",
                        State = "VA",
                        Country = "USA",
                        Zip = "22903"

                    }
                };

                var truck2 = new Truck
                {
                    //TruckId = 2,
                    Title = "Best Truck",
                    Price = 1,
                    Rating = 3.4m,
                    Hours = "9:00,10:00,12:00,13:00",
                    Phone = "4344664943",
                    Coordinates = new Coordinates
                    {
                        Latitude = 123.90m,
                        Longitude = 143.20m
                    },
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
                    CategoryName = "Thai"
                };


                var cat3 = new Category
                {
                    CategoryId = 3,
                    CategoryName = "Mexican"
                };

                var cat1 = new Category
                {
                    CategoryId = 2,
                    CategoryName = "Indian"
                };

                context.Categories.Add(cat2);

                context.TruckCategories.Add(new TruckCategory
                {
                    //CategoryId = 1,
                    Truck = truck1,
                    Category = cat2,
                    //TruckId = 1
                });


                context.TruckCategories.Add(new TruckCategory
                {
                    //CategoryId = 2,
                    Truck = truck1,
                    Category = cat1,
                    //TruckId = 1
                });

                context.TruckCategories.Add(new TruckCategory
                {
                    //CategoryId = 3,
                    Truck = truck2,
                    Category = cat3,
                    //TruckId = 2
                });

                context.SaveChanges();
            }
        }
    }
}