using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class AddSubmiterIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserSubmiterId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserSubmiterId",
                table: "Tickets",
                column: "UserSubmiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserSubmiterId",
                table: "Tickets",
                column: "UserSubmiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserSubmiterId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserSubmiterId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserSubmiterId",
                table: "Tickets");
        }
    }
}
