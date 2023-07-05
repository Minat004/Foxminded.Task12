using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTime.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Decimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "FinOperations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: 4000m);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: 133m);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: 150m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "FinOperations",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: 4000);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Value",
                value: 133);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Value",
                value: 100);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Value",
                value: 150);
        }
    }
}
