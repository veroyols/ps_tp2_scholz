using Domain.Entities;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IClientServices
    {
        //1.
        public Task<CreateClientResponse> CreateClient(CreateClientRequest request);
        public Task<List<Cliente>> GetClients();
        public Task<Cliente> GetClient(int clientId);
    }
}
