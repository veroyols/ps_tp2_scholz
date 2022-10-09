using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Orden
    {
        [Key]
        public Guid OrdenId { get; set; } //UUID PK
        public Guid CarritoId { get; set; } //UUID FK

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; } //.HasPrecision(15, 2);
        
        //Relaciones
        public Carrito Carrito { get; set; }
        
    }
}
