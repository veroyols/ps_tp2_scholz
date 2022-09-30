using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public async Task InsertCart(Carrito c)
        {
            _context.CarritoDb.Add(c);
            await _context.SaveChangesAsync();
            return;
        }

        //4 ?
        public async Task AddProductCart(CarritoProducto cp)
        {
            _context.CarritoProductoDb.Add(cp);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
