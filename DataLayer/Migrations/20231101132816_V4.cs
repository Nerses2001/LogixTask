using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_AspNetUsers_ApplicationUserId",
                table: "UserCourse");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UserCourse",
                newName: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_AspNetUsers_UserEmail",
                table: "UserCourse",
                column: "UserEmail",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_AspNetUsers_UserEmail",
                table: "UserCourse");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "UserCourse",
                newName: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_AspNetUsers_ApplicationUserId",
                table: "UserCourse",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
