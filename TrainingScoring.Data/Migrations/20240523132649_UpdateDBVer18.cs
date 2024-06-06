using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_ScoreDetails_ScoreDetailId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "ScoreDetails");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ScoreDetailId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "ScoreDetailId",
                table: "Scores",
                newName: "TotalScore");

            migrationBuilder.AddColumn<int>(
                name: "Ranking",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ranking",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "TotalScore",
                table: "Scores",
                newName: "ScoreDetailId");

            migrationBuilder.CreateTable(
                name: "ScoreDetails",
                columns: table => new
                {
                    ScoreDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoreDetailEvalution = table.Column<int>(type: "int", nullable: false),
                    ScoreDetailValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreDetails", x => x.ScoreDetailId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ScoreDetailId",
                table: "Scores",
                column: "ScoreDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_ScoreDetails_ScoreDetailId",
                table: "Scores",
                column: "ScoreDetailId",
                principalTable: "ScoreDetails",
                principalColumn: "ScoreDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
