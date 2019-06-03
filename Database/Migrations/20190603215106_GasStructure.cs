using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class GasStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Profiles_Id",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_Id",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "ControlId",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ConsumerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceCards_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MaintenanceCardId = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    CheckedConnection = table.Column<bool>(nullable: false),
                    CheckedBurning = table.Column<bool>(nullable: false),
                    CheckedTraction = table.Column<bool>(nullable: false),
                    CheckedMasonryStove = table.Column<bool>(nullable: false),
                    CheckedAutomationDebugging = table.Column<bool>(nullable: false),
                    OtherWorks = table.Column<bool>(nullable: false),
                    ConsumerInstructed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_MaintenanceCards_MaintenanceCardId",
                        column: x => x.MaintenanceCardId,
                        principalTable: "MaintenanceCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GasEquipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: false),
                    Mark = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: false),
                    ManufactureDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasEquipments_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerGasEquipments",
                columns: table => new
                {
                    ConsumerId = table.Column<Guid>(nullable: false),
                    GasEquipmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerGasEquipments", x => new { x.ConsumerId, x.GasEquipmentId });
                    table.ForeignKey(
                        name: "FK_ConsumerGasEquipments_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerGasEquipments_GasEquipments_GasEquipmentId",
                        column: x => x.GasEquipmentId,
                        principalTable: "GasEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Controls",
                columns: new[] { "Id", "Deleted", "Number" },
                values: new object[] { new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"),
                columns: new[] { "ControlId", "Password", "ProfileId" },
                values: new object[] { new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"), "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ControlId",
                table: "Users",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerGasEquipments_GasEquipmentId",
                table: "ConsumerGasEquipments",
                column: "GasEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GasEquipments_ManufacturerId",
                table: "GasEquipments",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCards_ConsumerId",
                table: "MaintenanceCards",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceCards_UserId",
                table: "MaintenanceCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_MaintenanceCardId",
                table: "Maintenances",
                column: "MaintenanceCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Profiles_Id",
                table: "Consumers",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Controls_ControlId",
                table: "Users",
                column: "ControlId",
                principalTable: "Controls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_Id",
                table: "Users",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Profiles_Id",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Controls_ControlId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_Id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ConsumerGasEquipments");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "GasEquipments");

            migrationBuilder.DropTable(
                name: "MaintenanceCards");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Users_ControlId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ControlId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67af6f37-55b6-4a84-a87e-d059416e0af6"),
                columns: new[] { "Password", "ProfileId" },
                values: new object[] { "123", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Profiles_Id",
                table: "Consumers",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_Id",
                table: "Users",
                column: "Id",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
