using Microsoft.EntityFrameworkCore.Migrations;

namespace BTracker.Migrations
{
    public partial class AddUserSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "Sections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ToUserId",
                table: "Sections",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AspNetUsers_ToUserId",
                table: "Sections",
                column: "ToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AspNetUsers_ToUserId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_ToUserId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Sections");
        }
    }
}
