using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassroomStart.Migrations
{
    public partial class initialmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "ID", "Address", "Name(First)", "Name(Last)", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "321 Elm Street", "Phil", "Esposito", "333-555-6767" },
                    { 2, "20 Compton Way", "Eric", "Clapton", "676-444-1234" },
                    { 3, "777 GTA V Street", "Bill", "Murray", "222-911-0000" },
                    { 4, "11 White House", "Nancy", "Peluso", "455-120-8888" },
                    { 5, "99 Beachwood Lane", "Sandy", "Seashore", "321-999-5657" },
                    { 6, "560 Hellsgate Inn", "Sara", "Bigwood", "400-000-0001" },
                    { 7, "411 Eagle Street", "Peter", "Gabriel", "299-877-0099" },
                    { 8, "100 Acre Woods", "Winnie", "DaPooh", "666-111-5450" },
                    { 9, "99 Peanuts Avenue", "Charlie", "Brown", "244-444-0003" },
                    { 10, "#2 Air Tonite Way", "Phil", "Collins", "321-999-0379" }
                });

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
            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "ID",
                keyValue: 10);

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
