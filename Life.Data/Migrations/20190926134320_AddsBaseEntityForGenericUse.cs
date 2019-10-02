using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.Data.Migrations
{
    public partial class AddsBaseEntityForGenericUse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExercisesInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ExercisesInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExercisesInfo");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ExercisesInfo");
        }
    }
}
