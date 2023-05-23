using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DATA.Migrations
{
    public partial class AddQuizRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Courses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "QuizReviewRequest",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    QuizId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizReviewRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizReviewRequest_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizReviewRequest_Quizs_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizReviewRequest_QuizId",
                table: "QuizReviewRequest",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizReviewRequest_UserId",
                table: "QuizReviewRequest",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizReviewRequest");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Courses");
        }
    }
}
