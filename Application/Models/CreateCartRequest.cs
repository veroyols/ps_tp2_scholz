using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateCartRequest
    {
        public int ClienteId { get; set; } //carrito
        public int ProductoId { get; set; } //cp
        public int Cantidad { get; set; } //cp
    }
}
