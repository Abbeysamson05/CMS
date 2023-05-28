using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DATA.Migrations
{
    public partial class Latestmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedBy",
                table: "Courses",
                newName: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AddedById",
                table: "Courses",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AddedById",
                table: "Courses",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AddedById",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AddedById",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "AddedById",
                table: "Courses",
                newName: "AddedBy");
        }
    }
}
