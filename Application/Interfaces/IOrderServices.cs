using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        Task<Orden> CreateOrder(Guid cartId, int clientId, decimal total);
        Task<List<Orden>> GetOrders(GetOrdersRequest orderRequest);
    }
}