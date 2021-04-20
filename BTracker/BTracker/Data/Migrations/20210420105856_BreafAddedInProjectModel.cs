using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Data.Migrations
{
    public partial class BreafAddedInProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectBrief",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectSmallBrief",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectBrief",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectSmallBrief",
                table: "Projects");
        }
    }
}
