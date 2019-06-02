using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class AuditsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialHours",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "InitialLocation_City",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "InitialLocation_Country",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "InitialLocation_State",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "InitialLocation_Street",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "InitialLocation_Zip",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "UpdatedLocation_State",
                table: "Audits");

            migrationBuilder.RenameColumn(
                name: "UpdatedLocation_Zip",
                table: "Audits",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "UpdatedLocation_Street",
                table: "Audits",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "UpdatedLocation_Country",
                table: "Audits",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "UpdatedLocation_City",
                table: "Audits",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "UpdatedHours",
                table: "Audits",
                newName: "Hours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Audits",
                newName: "UpdatedLocation_Zip");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Audits",
                newName: "UpdatedLocation_Street");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Audits",
                newName: "UpdatedLocation_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Audits",
                newName: "UpdatedLocation_City");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "Audits",
                newName: "UpdatedHours");

            migrationBuilder.AddColumn<string>(
                name: "InitialHours",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialLocation_City",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialLocation_Country",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialLocation_State",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialLocation_Street",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialLocation_Zip",
                table: "Audits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedLocation_State",
                table: "Audits",
                nullable: true);
        }
    }
}
