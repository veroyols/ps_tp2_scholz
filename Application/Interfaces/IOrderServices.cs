using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        public Task<Orden> CreateOrder(Guid cartId, int clientId, decimal total);
        public Task<List<Orden>> GetOrders(GetOrdersRequest orderRequest);
    }
}