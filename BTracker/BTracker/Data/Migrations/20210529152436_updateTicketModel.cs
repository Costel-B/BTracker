using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class updateTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserSubmiterId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "UserSubmiterId",
                table: "Tickets",
                newName: "SubmiterId");

            migrationBuilder.RenameColumn(
                name: "Submitter",
                table: "Tickets",
                newName: "SubmitterId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserSubmiterId",
                table: "Tickets",
                newName: "IX_Tickets_SubmiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_SubmiterId",
                table: "Tickets",
                column: "SubmiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_SubmiterId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "SubmitterId",
                table: "Tickets",
                newName: "Submitter");

            migrationBuilder.RenameColumn(
                name: "SubmiterId",
                table: "Tickets",
                newName: "UserSubmiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_SubmiterId",
                table: "Tickets",
                newName: "IX_Tickets_UserSubmiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserSubmiterId",
                table: "Tickets",
                column: "UserSubmiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
