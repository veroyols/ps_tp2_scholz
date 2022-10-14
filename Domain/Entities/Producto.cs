using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; } 
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        [MaxLength(25)]
        public string Marca { get; set; } 
        [MaxLength(25)]
        public string Codigo { get; set; }
        public decimal Precio { get; set; } 
        public string Image { get; set; } 

        //Relaciones
        public IList<CarritoProducto> CarritoProducto { get; set; }


    }
}
