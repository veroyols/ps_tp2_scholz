using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System.ComponentModel.Design;

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
        public async Task<string> AddProductCart(CreateCartRequest request, Carrito cart)
        {
            string message;
            var cp = new CarritoProducto
            {
                CarritoId = cart.CarritoId,
                ProductoId = request.ProductoId,
                Cantidad = request.Cantidad
            };

            ;
            if (_query.Exists(cp).Result)
            {
                await _command.AddAmount(cp, request.Cantidad);
                message = "Se han agregado mas unidades del producto. ";
            }
            else
            {
                await _command.InsertCP(cp);
                message = "Se ha agregado un nuevo producto. ";

            }
            return message;
        }

        //5. 
        public async Task UpdateCart(Carrito cart, CreateCartRequest req)
        {
            var cartProduct = _query.GetCartProduct(cart.CarritoId, req.ProductoId);
            await Task.Run(() => _command.ChangeAmount(cartProduct.Result, req.Cantidad));
        }

        //6.
        public async Task DeleteProduct(Carrito cart, int productId)
        {
            var cartProduct = _query.GetCartProduct(cart.CarritoId, productId);
            await _command.DeleteProduct(cartProduct.Result);
        }
    }
}
