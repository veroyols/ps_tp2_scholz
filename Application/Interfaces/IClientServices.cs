using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientServices
    {
        //op.1
        Task<Cliente> CreateClient();

        Task<Cliente> UpdateClient(int clientId);
        Task<List<Cliente>> GetClients();
        Task<Cliente> DeleteClient(int clientId);
        Task<Cliente> GetClient(int clientId);
    }
}
