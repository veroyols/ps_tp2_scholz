using Application.Interfaces;
using Application.Models;
using Domain.Entities;

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

        public async Task<Carrito> ValidarCarrito(CreateCartRequest req)
        {
            Carrito cart;
            try
            {
                cart = await _query.GetCarritoByClienteId(req.clientId); 
            }
            catch (Exception)
            {
                return null;
            }
            
            if (cart == null)
            {
                cart = new Carrito
                {
                    CarritoId = Guid.NewGuid(),
                    ClienteId = req.clientId,
                    Estado = true
                };
                await _command.InsertCart(cart);
            }
            return cart;
        }

        public async Task<Carrito> GetCartByClientId(int clientId)
        {
            return await _query.GetCarritoByClienteId(clientId); 
        }
        public async Task StatusFalse(Guid cartId)
        {
            await Task.FromResult(_command.StatusFalse(cartId));
        }

        //public async Task<Carrito> GetCart(int cartId)
        //{
        //    var c = await Task.Run(() => _query.GetCart(cartId));
        //    return c;
        //}

        //public async Task<List<Carrito>> GetCarts()
        //{
        //    var list = await Task.Run(() => _query.GetListCart());
        //    return list;
        //}
    }
}
