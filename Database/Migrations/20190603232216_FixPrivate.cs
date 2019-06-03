using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class FixPrivate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Structures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Structures");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Addresses");
        }
    }
}
