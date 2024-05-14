using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TraniningDetailProofs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingDirectories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingContents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingContentProofs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EvaluationForms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TraniningDetailProofs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingDirectories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingContentProofs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EvaluationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
