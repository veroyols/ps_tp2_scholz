using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; } //pk
        public string Nombre { get; set; } //nvarchar(max)
        public string Descripcion { get; set; } //nvarchar(max)
        [MaxLength(25)]
        public string Marca { get; set; } //nvarchar(25)
        [MaxLength(25)]
        public string Codigo { get; set; } //nvarchar(25)
        public decimal Precio { get; set; } //.HasColumnType("decimal(15, 2)");
        public string Image { get; set; } //nvarchar(max)

        //Relaciones
        public IList<CarritoProducto> CarritoProducto { get; set; }


    }
}
