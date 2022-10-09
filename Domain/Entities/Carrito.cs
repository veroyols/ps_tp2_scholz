using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Carrito
    {
        [Key]
        public Guid CarritoId { get; set; } //UUID PK
        public int ClienteId { get; set; } //FK
        public bool Estado { get; set; }

        //Relaciones
        public Cliente Cliente { get; set; }
        public IList<CarritoProducto> CarritoProducto { get; set; }
        public Orden Orden { get; set; }

    }
}
