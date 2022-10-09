using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderServices
    {
        Task<Orden> CreateOrder(int clientId);
        Task<List<Orden>> GetOrders();
    }
}