using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Levvel_backend_project.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    AuditId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InitialHours = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    TruckId = table.Column<int>(nullable: false),
                    TypeOfOperation = table.Column<string>(nullable: true),
                    UpdatedHours = table.Column<string>(nullable: true),
                    InitialLocation_City = table.Column<string>(nullable: true),
                    InitialLocation_Country = table.Column<string>(nullable: true),
                    InitialLocation_State = table.Column<string>(nullable: true),
                    InitialLocation_Street = table.Column<string>(nullable: true),
                    InitialLocation_Zip = table.Column<string>(nullable: true),
                    UpdatedLocation_City = table.Column<string>(nullable: true),
                    UpdatedLocation_Country = table.Column<string>(nullable: true),
                    UpdatedLocation_State = table.Column<string>(nullable: true),
                    UpdatedLocation_Street = table.Column<string>(nullable: true),
                    UpdatedLocation_Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.AuditId);
                });
        }
    }
}
