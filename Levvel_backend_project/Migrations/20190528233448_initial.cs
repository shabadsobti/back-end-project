using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Levvel_backend_project.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    TypeOfOperation = table.Column<string>(nullable: true),
                    TruckId = table.Column<int>(nullable: false),
                    InitialHours = table.Column<string>(nullable: true),
                    UpdatedHours = table.Column<string>(nullable: true),
                    InitialLocation_Street = table.Column<string>(nullable: true),
                    InitialLocation_City = table.Column<string>(nullable: true),
                    InitialLocation_State = table.Column<string>(nullable: true),
                    InitialLocation_Country = table.Column<string>(nullable: true),
                    InitialLocation_Zip = table.Column<string>(nullable: true),
                    UpdatedLocation_Street = table.Column<string>(nullable: true),
                    UpdatedLocation_City = table.Column<string>(nullable: true),
                    UpdatedLocation_State = table.Column<string>(nullable: true),
                    UpdatedLocation_Country = table.Column<string>(nullable: true),
                    UpdatedLocation_Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    Hours = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Coordinates_Latitude = table.Column<decimal>(nullable: false),
                    Coordinates_Longitude = table.Column<decimal>(nullable: false),
                    Location_Street = table.Column<string>(nullable: true),
                    Location_City = table.Column<string>(nullable: true),
                    Location_State = table.Column<string>(nullable: true),
                    Location_Country = table.Column<string>(nullable: true),
                    Location_Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.TruckId);
                });

            migrationBuilder.CreateTable(
                name: "TruckCategories",
                columns: table => new
                {
                    TruckId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckCategories", x => new { x.TruckId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TruckCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TruckCategories_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckCategories_CategoryId",
                table: "TruckCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "TruckCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Trucks");
        }
    }
}
