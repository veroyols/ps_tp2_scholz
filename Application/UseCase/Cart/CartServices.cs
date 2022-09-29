using Application.Interfaces;
using Application.Models;
using Domain.Entities;
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
        public async Task<Carrito> CreateCart(CreateCartRequest request)
        {
            //mapear request -> CP
            var c = new Carrito
            {
            ClienteId = request.ClienteId,
            
                //"clientId": 123,
		        //"productId": 123,
		        //"amount": 123
            };
            await _command.InsertCart(c);
            return c;
        }

    }
}
