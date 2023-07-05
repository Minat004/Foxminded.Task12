using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialTime.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinOperations_FinTypes_FinTypeId",
                        column: x => x.FinTypeId,
                        principalTable: "FinTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FinTypes",
                columns: new[] { "Id", "Budget", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Salary" },
                    { 2, 1, "Products" },
                    { 3, 1, "Fun" },
                    { 4, 1, "Restaurants" }
                });

            migrationBuilder.InsertData(
                table: "FinOperations",
                columns: new[] { "Id", "Date", "FinTypeId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4000 },
                    { 2, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1000 },
                    { 3, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 133 },
                    { 4, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 100 },
                    { 5, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinOperations_FinTypeId",
                table: "FinOperations",
                column: "FinTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinOperations");

            migrationBuilder.DropTable(
                name: "FinTypes");
        }
    }
}
