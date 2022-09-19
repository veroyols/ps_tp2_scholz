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
    public class ProductCommand : IProductCommand
    {
        //inyectar en el contexto
        private readonly AppDbContext _context;

        public ProductCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task InsertProduct(Producto product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
