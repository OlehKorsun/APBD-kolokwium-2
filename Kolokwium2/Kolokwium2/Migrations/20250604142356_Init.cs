using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    TemperatureCelsius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Washing_Machine",
                columns: table => new
                {
                    WashingMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxWeight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Washing_Machine", x => x.WashingMachineId);
                });

            migrationBuilder.CreateTable(
                name: "Available_Program",
                columns: table => new
                {
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WashingMachineId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_Program", x => x.AvailableProgramId);
                    table.ForeignKey(
                        name: "FK_Available_Program_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Available_Program_Washing_Machine_WashingMachineId",
                        column: x => x.WashingMachineId,
                        principalTable: "Washing_Machine",
                        principalColumn: "WashingMachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_History",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AvailableProgramId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_History", x => new { x.CustomerId, x.AvailableProgramId });
                    table.ForeignKey(
                        name: "FK_Purchase_History_Available_Program_AvailableProgramId",
                        column: x => x.AvailableProgramId,
                        principalTable: "Available_Program",
                        principalColumn: "AvailableProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_History_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "John", "Doe", null },
                    { 2, "Jane", "Doe", null },
                    { 3, "Julie", "Doe", null }
                });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramId", "DurationMinutes", "Name", "TemperatureCelsius" },
                values: new object[,]
                {
                    { 1, 50, "Program 1", 90 },
                    { 2, 60, "Program 2", 60 },
                    { 3, 15, "Program 3", 30 }
                });

            migrationBuilder.InsertData(
                table: "Washing_Machine",
                columns: new[] { "WashingMachineId", "MaxWeight", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 96.5m, "Serial number 1" },
                    { 2, 106m, "Serial number 2" },
                    { 3, 57.4m, "Serial number 3" }
                });

            migrationBuilder.InsertData(
                table: "Available_Program",
                columns: new[] { "AvailableProgramId", "Price", "ProgramId", "WashingMachineId" },
                values: new object[,]
                {
                    { 1, 9.99m, 1, 1 },
                    { 2, 15.99m, 2, 1 },
                    { 3, 68.99m, 3, 2 },
                    { 4, 19.99m, 2, 3 },
                    { 5, 95.99m, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Purchase_History",
                columns: new[] { "AvailableProgramId", "CustomerId", "PurchaseDate", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 1, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 2, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 3, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_ProgramId",
                table: "Available_Program",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Available_Program_WashingMachineId",
                table: "Available_Program",
                column: "WashingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_History_AvailableProgramId",
                table: "Purchase_History",
                column: "AvailableProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase_History");

            migrationBuilder.DropTable(
                name: "Available_Program");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Washing_Machine");
        }
    }
}
