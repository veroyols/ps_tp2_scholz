using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartProductCommand
    {
        public Task AddProductCart(CarritoProducto cp);
        public Task UpdateCart(CreateCartRequest cart);
        public Task DeleteProduct(int clientId, int productId);

    }
}
