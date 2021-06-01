using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class UpdateNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TicketId",
                table: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TicketId1",
                table: "Notes",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tickets_TicketId1",
                table: "Notes",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tickets_TicketId1",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TicketId1",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Notes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TicketId",
                table: "Notes",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
