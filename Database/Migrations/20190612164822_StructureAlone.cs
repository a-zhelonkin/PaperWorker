using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class StructureAlone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alone",
                table: "Structures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "EmailMessages",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alone",
                table: "Structures");

            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "EmailMessages",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
