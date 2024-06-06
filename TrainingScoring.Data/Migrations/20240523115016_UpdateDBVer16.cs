using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreDetailDate",
                table: "ScoreDetails");

            migrationBuilder.CreateTable(
                name: "StudentScoreContents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TrainingContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScoreContents", x => new { x.TrainingContentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentScoreContents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentScoreContents_TrainingContents_TrainingContentId",
                        column: x => x.TrainingContentId,
                        principalTable: "TrainingContents",
                        principalColumn: "TrainingContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentScoreDetails",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TrainingDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScoreDetails", x => new { x.TrainingDetailId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentScoreDetails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentScoreDetails_TrainingDetails_TrainingDetailId",
                        column: x => x.TrainingDetailId,
                        principalTable: "TrainingDetails",
                        principalColumn: "TrainingDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreContents_StudentId",
                table: "StudentScoreContents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreDetails_StudentId",
                table: "StudentScoreDetails",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentScoreContents");

            migrationBuilder.DropTable(
                name: "StudentScoreDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScoreDetailDate",
                table: "ScoreDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
