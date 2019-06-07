using Levvel_backend_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Levvel_backend_project
{
    public class ApiContext : IdentityDbContext<AppUser>
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TruckCategory> TruckCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerTrucks> CustomerTrucks { get; set; }
        public DbSet<Audit> Audits { get; set; }


     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=food_truck;Username=postgres;Password=Shabad@97");


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TruckCategory>()
           .HasKey(e => new { e.TruckId, e.CategoryId });

            builder.Entity<TruckCategory>()
            .HasOne(e => e.Truck)
            .WithMany(p => p.TruckCategory)
            .HasForeignKey(a => a.TruckId);

            builder.Entity<TruckCategory>()
            .HasOne(e => e.Category)
            .WithMany(p => p.TruckCategory)
            .HasForeignKey(a => a.CategoryId);

            builder.Entity<CustomerTrucks>().HasKey(sc => new { sc.CustomerId, sc.TruckId });

            builder.Entity<CustomerTrucks>()
                .HasOne<Customer>(sc => sc.Customer)
                .WithMany(s => s.Favorites)
                .HasForeignKey(sc => sc.CustomerId);

            builder.Entity<CustomerTrucks>()
                .HasOne<Truck>(sc => sc.Truck)
                .WithMany(s => s.CustomerTrucks)
                .HasForeignKey(sc => sc.TruckId);

        }
    }
}
