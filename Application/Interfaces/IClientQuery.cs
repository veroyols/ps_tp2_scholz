using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientQuery
    {
        public List<Cliente> GetListClient();
        public Task<Cliente> GetClient(int clientId);
    }
}
