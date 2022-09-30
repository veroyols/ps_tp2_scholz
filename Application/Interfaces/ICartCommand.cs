using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICartCommand
    {
        public Task InsertCart(Carrito c);
        public Task AddProductCart(CarritoProducto cp);
    }
}
