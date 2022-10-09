using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Nombre",
                value: "Buzo");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6,
                column: "Nombre",
                value: "Pantalon");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7,
                column: "Nombre",
                value: "Campera");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8,
                column: "Nombre",
                value: "Pantalon");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9,
                column: "Nombre",
                value: "Sweater");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Nombre",
                value: "Buzo Canguro");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6,
                column: "Nombre",
                value: "Pantalon Jogging");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7,
                column: "Nombre",
                value: "Campera Jean");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8,
                column: "Nombre",
                value: "Pantalon Jean");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9,
                column: "Nombre",
                value: "Sweater Bremer Negro");
        }
    }
}
