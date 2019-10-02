using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.Data.Migrations
{
    public partial class ChangesExerciseTypeToMoreSpecificName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ExercisesInfo");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseType",
                table: "ExercisesInfo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "ExercisesInfo");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ExercisesInfo",
                nullable: false,
                defaultValue: 0);
        }
    }
}
