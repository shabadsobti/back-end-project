using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CustomerTrucks",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    TruckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTrucks", x => new { x.CustomerId, x.TruckId });
                    table.ForeignKey(
                        name: "FK_CustomerTrucks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerTrucks_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "TruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrucks_TruckId",
                table: "CustomerTrucks",
                column: "TruckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTrucks");

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
    }
}
