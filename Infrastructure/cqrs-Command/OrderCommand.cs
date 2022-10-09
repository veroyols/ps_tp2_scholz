using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.cqrs_Command
{
    public class OrderCommand : IOrderCommand
    {
        private readonly AppDbContext _context;

        public OrderCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task InsertOrder(Orden order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
