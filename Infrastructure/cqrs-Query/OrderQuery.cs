using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.cqrs_Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly AppDbContext _context;

        public OrderQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Orden>> GetListOrder(GetOrdersRequest orderRequest)
        {
            var query = await Task.Run(() =>
                from o in _context.OrdenDb
                where o.Fecha > orderRequest.@from
                where o.Fecha < orderRequest.@to
                select o);
            return query.ToList();
        }
    }
}