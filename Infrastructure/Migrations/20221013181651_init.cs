using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 1, "", "", "", "admin", "" });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Image", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "ps2c2022-01", "Remera de algodon lisa, varios colores.", "https://drive.google.com/file/d/1AWEbI7NFytjQr0PcRNfqGjlWLDcW1BDr/view?usp=sharing", "Simpl", "Remera", 3000.00m },
                    { 2, "ps2c2022-02", "Buzo de friza liso, varios colores.", "https://drive.google.com/file/d/136zDTZUkUbs5Z4eoumK-Gm5J-Ex7aN2y/view?usp=sharing", "Simpl", "Buzo", 4000.00m },
                    { 3, "ps2c2022-03", "Canguro de friza liso, varios colores.", "https://drive.google.com/file/d/1OoBv1FyptSBujAqBvTV61F3zkm6GLeb6/view?usp=sharing", "Simpl", "Buzo Canguro", 4500.00m },
                    { 4, "ps2c2022-04", "Campera de frisa lisa, varios colores.", "https://drive.google.com/file/d/1zomCjyxcP1uyJxRonUVcAtDKC-y8LHmD/view?usp=sharing", "Simpl", "Campera", 5000.00m },
                    { 5, "ps2c2022-05", "Musculosa de algodon lisa, varios colores.", "https://drive.google.com/file/d/1DGa8_Ows-LfNxczRkvcBrQwX5lsh89_n/view?usp=sharing", "Simpl", "Musculosa", 2700.00m },
                    { 6, "ps2c2022-06", "Pantalon jogging de friza.", "https://drive.google.com/file/d/12P_zAj696O3cYBeWToXWM93nQEgIFlW0/view?usp=sharing", "Simpl", "Pantalon Jogging", 4700.00m },
                    { 7, "ps2c2022-07", "Campera de jean corta.", "https://drive.google.com/file/d/11-i6M5B8fZySpeS2XjaaEioi3Puq2DCS/view?usp=sharing", "Simpl", "Campera Jean", 4900.00m },
                    { 8, "ps2c2022-08", "Pantalon de jean claro.", "https://drive.google.com/file/d/1Vo-6YDNc4hoce7NkVrYVe3YQrf97QnG3/view?usp=sharing", "Simpl", "Pantalon Jean", 6300.00m },
                    { 9, "ps2c2022-09", "Sweater Bremer Negro.", "https://drive.google.com/file/d/16kEM1AO29k__3ayUe8zbe2DqodGbUzZ_/view?usp=sharing", "Simpl", "Sweater Bremer Negro", 5100.00m },
                    { 10, "ps2c2022-10", "Camiseta algodon, varios colores.", "https://drive.google.com/file/d/1udHiMsJF53vY67yJYEh9TRHon7e0w8vC/view?usp=sharing", "Simpl", "Camiseta", 5200.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
