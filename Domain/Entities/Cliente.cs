using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; } //PK
        [MaxLength(10)]
        public string DNI { get; set; }//nvarchar(10)
        [MaxLength(25)] 
        public string Nombre { get; set; }//nvarchar(25)
        [MaxLength(25)]
        public string Apellido { get; set; }//nvarchar(25)
        public string Direccion { get; set; } //nvarchar(max) 
        [MaxLength(13)] 
        public string Telefono { get; set; }//nvarchar(13)
        
        //Relacion
        public IList<Carrito> Carritos { get; set; }
    }
}
