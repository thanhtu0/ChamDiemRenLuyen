using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "Roles");
        }
    }
}
