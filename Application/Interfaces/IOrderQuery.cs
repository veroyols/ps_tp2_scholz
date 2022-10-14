using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderQuery
    {
        public Task<List<Orden>> GetListOrder(GetOrdersRequest orderRequest);
    }
}
