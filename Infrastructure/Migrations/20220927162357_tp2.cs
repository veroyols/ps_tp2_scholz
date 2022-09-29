using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class tp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Orden_CarritoId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProducto_Carrito_CarritoId",
                table: "CarritoProducto");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 1, "", "", "", "admin", "" });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Image", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "ps2c2022-01", "Remera de algodon lisa, varios colores.", "remera.png", "Simpl", "Remera", 3000.00m },
                    { 2, "ps2c2022-02", "Buzo de friza liso, varios colores.", "buzo.png", "Simpl", "Buzo", 4000.00m },
                    { 3, "ps2c2022-03", "Canguro de friza liso, varios colores.", "canguro.png", "Simpl", "Buzo Canguro", 4500.00m },
                    { 4, "ps2c2022-04", "Campera de frisa lisa, varios colores.", "campera.png", "Simpl", "Campera", 5000.00m },
                    { 5, "ps2c2022-05", "Musculosa de algodon lisa, varios colores.", "musculosa.png", "Simpl", "Musculosa", 2700.00m },
                    { 6, "ps2c2022-06", "Pantalon jogging de friza.", "jogging.png", "Simpl", "Pantalon Jogging", 4700.00m },
                    { 7, "ps2c2022-07", "Campera de jean corta.", "campera.png", "Simpl", "Campera Jean", 4900.00m },
                    { 8, "ps2c2022-08", "Pantalon de jean claro.", "jean.png", "Simpl", "Pantalon Jean", 6300.00m },
                    { 9, "ps2c2022-09", "Sweater Bremer Negro.", "bremer.png", "Simpl", "Sweater Bremer Negro", 5100.00m },
                    { 10, "ps2c2022-10", "Camiseta algodon, varios colores.", "camiseta.png", "Simpl", "Camiseta", 5200.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProducto_Carrito_CarritoId",
                table: "CarritoProducto",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orden_Carrito_CarritoId",
                table: "Orden",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_CarritoProducto_Carrito_CarritoId",
                table: "CarritoProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Orden_Carrito_CarritoId",
                table: "Orden");

            migrationBuilder.DropIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden");

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "ProductoId",
                keyValue: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Orden_CarritoId",
                table: "Carrito",
                column: "CarritoId",
                principalTable: "Orden",
                principalColumn: "OrdenId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarritoProducto_Carrito_CarritoId",
                table: "CarritoProducto",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId");
        }
    }
}
