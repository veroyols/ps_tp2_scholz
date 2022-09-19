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
    public class OrderCommand : IOrderCommand
    {
        //inyectar en el context
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
