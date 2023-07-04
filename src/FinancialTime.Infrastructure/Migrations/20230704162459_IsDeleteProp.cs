using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTime.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsDeleteProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "FinTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "FinOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinOperations",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "FinTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDelete",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "FinTypes");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "FinOperations");
        }
    }
}
