using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DATA.Migrations
{
    public partial class EntityModificationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Stacks_StackId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_StackId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "StackId",
                table: "UserCourses");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserStack",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserStack",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserQuizTaken",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserQuizTaken",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserCourses",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserCourses",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Stacks",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Stacks",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Quizs",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Quizs",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                table: "Quizs",
                newName: "AddedById");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "QuizOptions",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "QuizOptions",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Lessons",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Lessons",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Invites",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Invites",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Courses",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Courses",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AspNetUsers",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AspNetUsers",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCourses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedById",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizs_AddedById",
                table: "Quizs",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizs_AspNetUsers_AddedById",
                table: "Quizs",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_AspNetUsers_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizs_AspNetUsers_AddedById",
                table: "Quizs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_AspNetUsers_UserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_Quizs_AddedById",
                table: "Quizs");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "UserStack",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserStack",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "UserQuizTaken",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserQuizTaken",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "UserCourses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserCourses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Stacks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Stacks",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Quizs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Quizs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "AddedById",
                table: "Quizs",
                newName: "AddedBy");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "QuizOptions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "QuizOptions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Lessons",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Lessons",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Invites",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Invites",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Courses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Courses",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "AspNetUsers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "AspNetUsers",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCourses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserCourses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StackId",
                table: "UserCourses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddedById",
                table: "Lessons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_ApplicationUserId",
                table: "UserCourses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_StackId",
                table: "UserCourses",
                column: "StackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApplicationUserId",
                table: "UserCourses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Stacks_StackId",
                table: "UserCourses",
                column: "StackId",
                principalTable: "Stacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
