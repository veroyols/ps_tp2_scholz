using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; } //PK
        [MaxLength(10)]
        public string DNI { get; set; }//nvarchar(10)
        [MaxLength(25)] 
        public string Name { get; set; }//nvarchar(25)
        [MaxLength(25)]
        public string Lastname { get; set; }//nvarchar(25)
        public string Address { get; set; } //nvarchar(max) = string
        [MaxLength(13)] 
        public string Phone { get; set; }//nvarchar(13)
        
        //Relacion
        public IList<Cart> Carts { get; set; }
    }
}
