using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class CreatedByField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Created_byId",
                table: "Trucks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_Created_byId",
                table: "Trucks",
                column: "Created_byId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Customers_Created_byId",
                table: "Trucks",
                column: "Created_byId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Customers_Created_byId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_Created_byId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Created_byId",
                table: "Trucks");
        }
    }
}
