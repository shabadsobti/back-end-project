using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Trucks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_CustomerId",
                table: "Trucks",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Customers_CustomerId",
                table: "Trucks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Customers_CustomerId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_CustomerId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Trucks");
        }
    }
}
