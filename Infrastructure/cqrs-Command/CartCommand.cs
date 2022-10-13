using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.cqrs_Command
{
    public class CartCommand : ICartCommand
    {
        private readonly AppDbContext _context;

        public CartCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertCart(Carrito c)
        {
            _context.CarritoDb.Add(c);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task StatusFalse(Guid cartId)
        {
            var c = _context.CarritoDb.FirstOrDefault(x => x.CarritoId == cartId);
            if (c != null)
            {
                await Task.Run(() => c.Estado = false);
            }
        }
    }
}
