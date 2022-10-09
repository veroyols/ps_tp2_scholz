using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.cqrs_Query
{
    public class OrderQuery : IOrderQuery
    {
        public Orden GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Orden> GetListOrder()
        {
            throw new NotImplementedException();
        }
    }
}