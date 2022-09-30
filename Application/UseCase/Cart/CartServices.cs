using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.CartProduct
{
    public class CartServices : ICartServices
    {
        private readonly ICartCommand _command;
        private readonly ICartQuery _query;
        public CartServices(ICartCommand command, ICartQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<CreateCartRequest> AddProductCart(CreateCartRequest request)
        {
            //"clientId": 123, c
            //"productId": 123, cp
            //"amount": 123 cp
            var c = await _query.GetCarritoByClienteId(request.ClienteId);
            if (c == null)
            {
                c = new Carrito
                {
                    CarritoId = Guid.NewGuid(),
                    ClienteId = request.ClienteId,
                    Estado = true
                };
                await _command.InsertCart(c);
            }

            var cp = new CarritoProducto
            {
                CarritoId = c.CarritoId,
                ProductoId = request.ProductoId,
                Cantidad = request.Cantidad
            };

            //if Exists(cp)
            //Cantidad++

            await _command.AddProductCart(cp);

            var r = new CreateCartRequest
            {
                ClienteId = c.ClienteId,
                ProductoId = cp.ProductoId,
                Cantidad = cp.Cantidad
            };
            return r;
        }
    }
}
