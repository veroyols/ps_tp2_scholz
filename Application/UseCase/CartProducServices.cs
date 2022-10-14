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
        public async Task<string> AddProductCart(CreateCartRequest request, Carrito cart)
        {
            string message;
            var cp = new CarritoProducto
            {
                CarritoId = cart.CarritoId,
                ProductoId = request.productId,
                Cantidad = request.amount
            };

            ;
            if (_query.Exists(cp).Result)
            {
                await _command.AddAmount(cp, request.amount);
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
            var cartProduct = _query.GetCartProduct(cart.CarritoId, req.productId);
            await Task.Run(() => _command.ChangeAmount(cartProduct.Result, req.amount));
        }

        //6.
        public async Task DeleteProduct(Carrito cart, int productId)
        {
            var cartProduct = _query.GetCartProduct(cart.CarritoId, productId);
            await _command.DeleteProduct(cartProduct.Result);
        }

        public async Task<List<ItemCartProduct>> GetCartProduct(Guid carritoId)
        {
            var list = await _query.GetCartProduct(carritoId);
            var list2 = new List<ItemCartProduct>();
            foreach (var cp in list)
            {
                list2.Add(new ItemCartProduct
                {
                    productoId = cp.ProductoId,
                    cantidad = cp.Cantidad,
                });
            }
            return list2;
        }
    }
}
