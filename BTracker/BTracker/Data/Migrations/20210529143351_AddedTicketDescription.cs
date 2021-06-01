using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class AddedTicketDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketDescription",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketDescription",
                table: "Tickets");
        }
    }
}
