using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.Data.Migrations
{
    public partial class addsdurationset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Set",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Set",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Set");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Set");
        }
    }
}
