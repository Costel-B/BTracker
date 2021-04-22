using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Data.Migrations
{
    public partial class AddBooleanTaske : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Taskes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Taskes");
        }
    }
}
