using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartServices
    {
        public Task<Carrito> ValidarCarrito(CreateCartRequest req);
        public Task<Carrito> GetCartByClientId(int clientId);
        public Task StatusFalse(Guid cartId);
        
        //public Task<List<Carrito>> GetCarts();
        //public Task<Carrito> GetCart(int clientId);

    }
}
