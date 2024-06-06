using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoringProcesses_ScoringProcessProcessId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ScoringProcessProcessId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ScoringProcessProcessId",
                table: "Scores");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ProcessId",
                table: "Scores",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoringProcesses_ProcessId",
                table: "Scores",
                column: "ProcessId",
                principalTable: "ScoringProcesses",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoringProcesses_ProcessId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ProcessId",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "ScoringProcessProcessId",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ScoringProcessProcessId",
                table: "Scores",
                column: "ScoringProcessProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoringProcesses_ScoringProcessProcessId",
                table: "Scores",
                column: "ScoringProcessProcessId",
                principalTable: "ScoringProcesses",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
