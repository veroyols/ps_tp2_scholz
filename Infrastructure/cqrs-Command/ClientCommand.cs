using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.cqrs_Command
{
    public class ClientCommand : IClientCommand
    {
        private readonly AppDbContext _context;

        public ClientCommand(AppDbContext context)
        {
            _context = context;
        }
        
        //1.
        public async Task InsertClient(Cliente client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();  
        } 
    }
}
