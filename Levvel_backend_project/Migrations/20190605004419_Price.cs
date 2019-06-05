using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Trucks",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Trucks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
