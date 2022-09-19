using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Order
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderCommand _command;
        private readonly IOrderQuery _query;

        public OrderServices(IOrderCommand command, IOrderQuery query)
        {
            _command = command;
            _query = query;
        }

        //op2
        public Task<Domain.Entities.Orden> CreateOrder()
        {
            throw new NotImplementedException();
        }
        //op3
        public Task<List<Domain.Entities.Orden>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Orden> DeleteOrder(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Orden> GetOrder(int productId)
        {
            throw new NotImplementedException();
        }
        public Task<Domain.Entities.Orden> UpdateOrder(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
