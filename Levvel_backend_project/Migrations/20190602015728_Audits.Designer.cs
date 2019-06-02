﻿// <auto-generated />
using System;
using Levvel_backend_project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Levvel_backend_project.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20190602015728_Audits")]
    partial class Audits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Levvel_backend_project.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Audit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InitialHours");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("TruckId");

                    b.Property<string>("TypeOfOperation");

                    b.Property<string>("UpdatedHours");

                    b.HasKey("AuditId");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.CustomerTrucks", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("TruckId");

                    b.HasKey("CustomerId", "TruckId");

                    b.HasIndex("TruckId");

                    b.ToTable("CustomerTrucks");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hours");

                    b.Property<string>("Phone");

                    b.Property<int>("Price");

                    b.Property<decimal>("Rating");

                    b.Property<string>("Title");

                    b.HasKey("TruckId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.TruckCategory", b =>
                {
                    b.Property<int>("TruckId");

                    b.Property<int>("CategoryId");

                    b.HasKey("TruckId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TruckCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Audit", b =>
                {
                    b.OwnsOne("Levvel_backend_project.Models.Address", "InitialLocation", b1 =>
                        {
                            b1.Property<int>("AuditId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("State");

                            b1.Property<string>("Street");

                            b1.Property<string>("Zip");

                            b1.HasKey("AuditId");

                            b1.ToTable("Audits");

                            b1.HasOne("Levvel_backend_project.Models.Audit")
                                .WithOne("InitialLocation")
                                .HasForeignKey("Levvel_backend_project.Models.Address", "AuditId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Levvel_backend_project.Models.Address", "UpdatedLocation", b1 =>
                        {
                            b1.Property<int>("AuditId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("State");

                            b1.Property<string>("Street");

                            b1.Property<string>("Zip");

                            b1.HasKey("AuditId");

                            b1.ToTable("Audits");

                            b1.HasOne("Levvel_backend_project.Models.Audit")
                                .WithOne("UpdatedLocation")
                                .HasForeignKey("Levvel_backend_project.Models.Address", "AuditId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Customer", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("Levvel_backend_project.Models.CustomerTrucks", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.Customer", "Customer")
                        .WithMany("Favorites")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Levvel_backend_project.Models.Truck", "Truck")
                        .WithMany("CustomerTrucks")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Levvel_backend_project.Models.Truck", b =>
                {
                    b.OwnsOne("Levvel_backend_project.Models.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<int>("TruckId");

                            b1.Property<decimal>("Latitude");

                            b1.Property<decimal>("Longitude");

                            b1.HasKey("TruckId");

                            b1.ToTable("Trucks");

                            b1.HasOne("Levvel_backend_project.Models.Truck")
                                .WithOne("Coordinates")
                                .HasForeignKey("Levvel_backend_project.Models.Coordinates", "TruckId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Levvel_backend_project.Models.Address", "Location", b1 =>
                        {
                            b1.Property<int>("TruckId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("State");

                            b1.Property<string>("Street");

                            b1.Property<string>("Zip");

                            b1.HasKey("TruckId");

                            b1.ToTable("Trucks");

                            b1.HasOne("Levvel_backend_project.Models.Truck")
                                .WithOne("Location")
                                .HasForeignKey("Levvel_backend_project.Models.Address", "TruckId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Levvel_backend_project.Models.TruckCategory", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.Category", "Category")
                        .WithMany("TruckCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Levvel_backend_project.Models.Truck", "Truck")
                        .WithMany("TruckCategory")
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Levvel_backend_project.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Levvel_backend_project.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
