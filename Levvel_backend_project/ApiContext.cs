using System;
using Levvel_backend_project.Models;
using Microsoft.EntityFrameworkCore;



namespace Levvel_backend_project
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TruckCategory> TruckCategories { get; set; }

        public DbSet<Audit> Audits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TruckCategory>()
           .HasKey(e => new { e.TruckId, e.CategoryId });

            modelBuilder.Entity<TruckCategory>()
            .HasOne(e => e.Truck)
            .WithMany(p => p.TruckCategory)
            .HasForeignKey(a => a.TruckId);

            modelBuilder.Entity<TruckCategory>()
            .HasOne(e => e.Category)
            .WithMany(p => p.TruckCategory)
            .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<Audit>()
            .HasKey(o => o.AuditId);
        }
    }
}
