using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICartCommand
    {
        public Task InsertCart(Carrito c);
        public Task StatusFalse(Guid cartId);

    }
}
