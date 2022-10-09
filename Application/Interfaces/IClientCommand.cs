using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientCommand
    {
        public Task InsertClient(Cliente client);
    }
}
