using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DATA.Migrations
{
    public partial class RelationshipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stacks",
                newName: "StackName");

            migrationBuilder.AddColumn<bool>(
                name: "CompletionStatus",
                table: "UserQuizTaken",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "QuizId",
                table: "UserQuizTaken",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserQuizTaken",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserQuizTaken",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserCourses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "UserCourses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StackId",
                table: "UserCourses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserCourses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerType",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LessonId",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferedAnswer",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Quizs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "QuizOptions",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuizId",
                table: "QuizOptions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "Lessons",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CompletionStatus",
                table: "Lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Module",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Lessons",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weeks",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Invites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Invites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Invites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Invites",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActiveStatus",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizTaken_QuizId",
                table: "UserQuizTaken",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizTaken_UserId",
                table: "UserQuizTaken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_ApplicationUserId",
                table: "UserCourses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_StackId",
                table: "UserCourses",
                column: "StackId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizs_LessonId",
                table: "Quizs",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuizId",
                table: "QuizOptions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AddedById",
                table: "Lessons",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizOptions_Quizs_QuizId",
                table: "QuizOptions",
                column: "QuizId",
                principalTable: "Quizs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizs_Lessons_LessonId",
                table: "Quizs",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApplicationUserId",
                table: "UserCourses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Stacks_StackId",
                table: "UserCourses",
                column: "StackId",
                principalTable: "Stacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizTaken_AspNetUsers_UserId",
                table: "UserQuizTaken",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizTaken_Quizs_QuizId",
                table: "UserQuizTaken",
                column: "QuizId",
                principalTable: "Quizs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_AddedById",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizOptions_Quizs_QuizId",
                table: "QuizOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizs_Lessons_LessonId",
                table: "Quizs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_AspNetUsers_ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Stacks_StackId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizTaken_AspNetUsers_UserId",
                table: "UserQuizTaken");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizTaken_Quizs_QuizId",
                table: "UserQuizTaken");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizTaken_QuizId",
                table: "UserQuizTaken");

            migrationBuilder.DropIndex(
                name: "IX_UserQuizTaken_UserId",
                table: "UserQuizTaken");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_StackId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_Quizs_LessonId",
                table: "Quizs");

            migrationBuilder.DropIndex(
                name: "IX_QuizOptions_QuizId",
                table: "QuizOptions");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_AddedById",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CompletionStatus",
                table: "UserQuizTaken");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "UserQuizTaken");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserQuizTaken");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserQuizTaken");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "StackId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "AnswerType",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "PreferedAnswer",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Quizs");

            migrationBuilder.DropColumn(
                name: "Option",
                table: "QuizOptions");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "QuizOptions");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CompletionStatus",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Weeks",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StackName",
                table: "Stacks",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Courses",
                type: "text",
                nullable: true);
        }
    }
}