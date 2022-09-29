using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.cqrs_Command
{
    public class CartCommand : ICartCommand
    {
        private readonly AppDbContext _context;

        public CartCommand(AppDbContext context)
        {
            _context = context;
        }
        //4
        public async Task InsertCart(Carrito car)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
