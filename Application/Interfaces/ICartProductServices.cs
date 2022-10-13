using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartProductServices
    {
        public Task<string> AddProductCart(CreateCartRequest request, Carrito cart);
        public Task UpdateCart(Carrito cart, CreateCartRequest req);
        public Task DeleteProduct(Carrito cart, int productId);
        public Task<List<ItemCartProduct>> GetCartProduct(Guid carritoId);

    }
}
