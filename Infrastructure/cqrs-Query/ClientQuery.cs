using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.cqrs_Query
{
    public class ClientQuery : IClientQuery
    {
        public Cliente GetClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetListClient()
        {
            throw new NotImplementedException();
        }
    }
}
