using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDatabaseVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvalutionFormCode",
                table: "EvaluationForms",
                newName: "EvaluationFormCode");

            migrationBuilder.RenameColumn(
                name: "EvalutionFormId",
                table: "EvaluationForms",
                newName: "EvaluationFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EvaluationFormCode",
                table: "EvaluationForms",
                newName: "EvalutionFormCode");

            migrationBuilder.RenameColumn(
                name: "EvaluationFormId",
                table: "EvaluationForms",
                newName: "EvalutionFormId");
        }
    }
}
