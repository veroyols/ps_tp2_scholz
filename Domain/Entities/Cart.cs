using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; } //UUID PK
        public int ClientId { get; set; } //FK
        public byte[] Status { get; set; }

        //Relaciones
        public Client Client { get; set; }
        public IList<CartProduct> CartProduct { get; set; }
        public Order Order { get; set; }

    }
}
