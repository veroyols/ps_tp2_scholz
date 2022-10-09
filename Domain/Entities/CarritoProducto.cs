using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CarritoProducto
    {
        [Key]
        public Guid CarritoId { get; set; } //UUID PK FK
        [Key]
        public int ProductoId { get; set; } //PK FK
        public int Cantidad { get; set; } 

        //Relaciones
        public Carrito Carrito { get; set; }
        public Producto Producto { get; set; }
    }
}
