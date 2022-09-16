using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartProduct
    {
        [Key]
        public int CartId { get; set; } //UUID PK FK
        [Key]
        public int ProductId { get; set; } //PK FK
        public int Amount { get; set; } 

        //Relaciones
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
