using Application.Interfaces;

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

        //7.
        public Task<Domain.Entities.Orden> CreateOrder(int clientId)
        {
            throw new NotImplementedException();
        }
        //8.
        public Task<List<Domain.Entities.Orden>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
