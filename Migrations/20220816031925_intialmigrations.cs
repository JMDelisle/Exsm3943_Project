using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class intialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 1,
                column: "SalePrice",
                value: 360.000m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 2,
                column: "SalePrice",
                value: 320.000m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 3,
                column: "SalePrice",
                value: 960.000m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 4,
                column: "SalePrice",
                value: 800.000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 1,
                column: "SalePrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 2,
                column: "SalePrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 3,
                column: "SalePrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "ID",
                keyValue: 4,
                column: "SalePrice",
                value: 0m);
        }
    }
}
