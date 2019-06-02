using Microsoft.EntityFrameworkCore.Migrations;

namespace Levvel_backend_project.Migrations
{
    public partial class AuditsChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Audits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Audits");
        }
    }
}
