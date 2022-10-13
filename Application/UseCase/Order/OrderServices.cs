using Application.Interfaces;
using Application.Models;
using Domain.Entities;

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
        public async Task<Orden> CreateOrder(Guid cartId, int clientId, decimal total)
        {
            Orden orden = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = cartId,
                Total = total,
                Fecha = DateTime.Now,
            };
            await _command.InsertOrder(orden);
            return orden;
        }

        //8.
        public Task<List<Orden>> GetOrders(GetOrdersRequest orderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
