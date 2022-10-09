using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [MaxLength(10)]
        public string DNI { get; set; }
        [MaxLength(25)] 
        public string Nombre { get; set; }
        [MaxLength(25)]
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        [MaxLength(13)] 
        public string Telefono { get; set; }
        
        //Relacion
        public IList<Carrito> Carritos { get; set; }
    }
}
