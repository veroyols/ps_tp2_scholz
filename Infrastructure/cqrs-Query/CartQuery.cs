using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.cqrs_Query
{
    public class CartQuery : ICartQuery
    {
        private readonly AppDbContext _context;

        public CartQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carrito> GetCart(int clientId)
        {
            var c = await _context.CarritoDb.FirstOrDefaultAsync(cli => cli.ClienteId == clientId);
            return c;
        }
        public List<Carrito> GetListCart()
        {
            var list = _context.CarritoDb.ToList<Carrito>();
            return list;
        }
        public async Task<Carrito> GetCarritoByClienteId(int clientId)
        {
            var cart = await _context.CarritoDb
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(x => x.ClienteId == clientId && x.Estado);
            return cart; 
        }
    }
}
