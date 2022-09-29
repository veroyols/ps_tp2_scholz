using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.cqrs_Query
{
    public class ClientQuery : IClientQuery
    {
        private readonly AppDbContext _context;

        public ClientQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Cliente> GetClient(int clientId)
        {
            var c = await _context.ClienteDb.FirstOrDefaultAsync(cli => cli.ClienteId == clientId);
            return c;
        }
        public List<Cliente> GetListClient()
        {
            var list = _context.ClienteDb.ToList<Cliente>(); 
            return list;
        }
    }
}
