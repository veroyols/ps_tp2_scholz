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
    public class ClientCommand : IClientCommand
    {
        //inyectar en el context
        private readonly AppDbContext _context;

        public ClientCommand(AppDbContext context)
        {
            _context = context;
        }
        //op1 - insert
        public async Task InsertClient(Cliente client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();  
        } 
    }
}
