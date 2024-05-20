using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class UpdateDBVer13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Lecturers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "Contactaddress",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lecturerclassification",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobiePhone",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Workplaceunit",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contactaddress",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Lecturerclassification",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "MobiePhone",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "Workplaceunit",
                table: "Lecturers");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Lecturers",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
