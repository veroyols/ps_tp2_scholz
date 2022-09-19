using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Client
{
    public class ClientServices : IClientServices
    {
        private readonly IClientCommand _command;
        private readonly IClientQuery _query;

        public ClientServices(IClientCommand command, IClientQuery query)
        {
            _command = command;
            _query = query;
        }

        //op.1
        public Task<Domain.Entities.Cliente> CreateClient()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Cliente> DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }
        public Task<Domain.Entities.Cliente> GetClient(int clientId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Domain.Entities.Cliente>> GetClients()
        {
            throw new NotImplementedException();
        }
        public Task<Domain.Entities.Cliente> UpdateClient(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
