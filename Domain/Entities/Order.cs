using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; } //UUID PK
        public int CartId { get; set; } //UUID FK

        public DateTime Date { get; set; }
        public decimal Total { get; set; } //.HasPrecision(15, 2);
        
        //Relaciones
        public Cart Cart { get; set; }
        
    }
}
