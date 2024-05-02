using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class ChangeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProof");

            migrationBuilder.DropIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProof");

            migrationBuilder.DropIndex(
                name: "IX_ProcessDetail_RoleId",
                table: "ProcessDetail");

            migrationBuilder.CreateIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProof",
                column: "ProofId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProof",
                column: "ProofId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDetail_RoleId",
                table: "ProcessDetail",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProof");

            migrationBuilder.DropIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProof");

            migrationBuilder.DropIndex(
                name: "IX_ProcessDetail_RoleId",
                table: "ProcessDetail");

            migrationBuilder.CreateIndex(
                name: "IX_TraniningDetailProof_ProofId",
                table: "TraniningDetailProof",
                column: "ProofId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContentProof_ProofId",
                table: "TrainingContentProof",
                column: "ProofId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDetail_RoleId",
                table: "ProcessDetail",
                column: "RoleId",
                unique: true);
        }
    }
}
