using Application.Interfaces;
using Application.Models;
using Domain.Entities;

namespace Application.UseCase
{
    public class CartProducServices : ICartProductServices
    {
        private readonly ICartProductCommand _command;
        private readonly ICartProductQuery _query;

        public CartProducServices(ICartProductCommand command, ICartProductQuery query)
        {
            _command = command;
            _query = query;
        }

        //4.
        public async Task<CreateCartRequest> AddProductCart(CreateCartRequest request, Carrito cart)
        {
            var cp = new CarritoProducto
            {
                CarritoId = cart.CarritoId,
                ProductoId = request.ProductoId,
                Cantidad = request.Cantidad
            };

            //if Exists(cp)
            //Cantidad++

            await _command.AddProductCart(cp);

            var r = new CreateCartRequest
            {
                ClienteId = cart.ClienteId,
                ProductoId = cp.ProductoId,
                Cantidad = cp.Cantidad
            };
            return r;
        }

        //5.
        public async Task UpdateCart(CreateCartRequest cart)
        {
            await Task.Run(() => _command.UpdateCart(cart));
        }

        //6.
        public async Task<Func<Task>> DeleteProduct(int clientId, int productId)
        {
            return await Task.FromResult(() => _command.DeleteProduct(clientId, productId));
        }
    }
}
