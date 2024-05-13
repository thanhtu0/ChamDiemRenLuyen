using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingScoring.Data.Migrations
{
    public partial class CreateTrainingScoringDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TraniningDetailProofs");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "TrainingContentProofs");

            migrationBuilder.RenameColumn(
                name: "DateStarted",
                table: "EvaluationForms",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DateFinished",
                table: "EvaluationForms",
                newName: "CreateAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TraniningDetailProofs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TraniningDetailProofs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "TrainingDirectories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TrainingDirectories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingDirectories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "TrainingDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TrainingDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "TrainingContents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TrainingContents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TrainingContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TrainingContentProofs",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TraniningDetailProofs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TraniningDetailProofs");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "TrainingDirectories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TrainingDirectories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingDirectories");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "TrainingDetails");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TrainingDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingDetails");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "TrainingContents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TrainingContents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingContents");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TrainingContentProofs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TrainingContentProofs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EvaluationForms");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "EvaluationForms",
                newName: "DateStarted");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "EvaluationForms",
                newName: "DateFinished");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TraniningDetailProofs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "TrainingContentProofs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
