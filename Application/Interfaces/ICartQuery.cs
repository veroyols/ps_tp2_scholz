using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartQuery
    {
        public Task<Carrito> GetCarritoByClienteId(int clientId);
        public List<Carrito> GetListCart();
        public Task<Carrito> GetCart(int cartId);

    }
}
