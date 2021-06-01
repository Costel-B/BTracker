using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class UpdateHistoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Tickets_TicketId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_TicketId",
                table: "Histories");

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId1",
                table: "Histories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_TicketId1",
                table: "Histories",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Tickets_TicketId1",
                table: "Histories",
                column: "TicketId1",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Tickets_TicketId1",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_TicketId1",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "Histories");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "Histories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Histories_TicketId",
                table: "Histories",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Tickets_TicketId",
                table: "Histories",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
