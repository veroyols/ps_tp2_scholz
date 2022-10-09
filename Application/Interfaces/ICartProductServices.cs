using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartProductServices
    {
        public Task<CreateCartRequest> AddProductCart(CreateCartRequest request, Carrito cart);
        public Task UpdateCart(CreateCartRequest cart);
        public Task<Func<Task>> DeleteProduct(int clientId, int productId);

    }
}
