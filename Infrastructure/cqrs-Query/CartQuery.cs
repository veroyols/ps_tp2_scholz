using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.cqrs_Query
{
    public class CartQuery : ICartQuery
    {
        private readonly AppDbContext _context;

        public CartQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Carrito> GetCarritoByClienteId(int clientId)
        {
            var cart = await _context.CarritoDb
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(x => x.ClienteId == clientId && x.Estado == true);
            return cart; 
        }
    }
}
