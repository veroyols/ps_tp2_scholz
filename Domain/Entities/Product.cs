using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } //pk
        public string Name { get; set; } //nvarchar(max)
        public string Description { get; set; } //nvarchar(max)
        [MaxLength(25)]
        public string TradeMark { get; set; } //nvarchar(25)
        [MaxLength(25)]
        public string Code { get; set; } //nvarchar(25)
        public decimal Price { get; set; } //.HasPrecision(15, 2);
        public string Image { get; set; } //nvarchar(max)

        //Relaciones
        public IList<CartProduct> CartProduct { get; set; }


    }
}
