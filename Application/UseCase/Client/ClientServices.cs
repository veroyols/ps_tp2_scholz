using Application.Interfaces;
using Domain.Entities;
using Domain.Models;
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
        //1
        public async Task<CreateClientRequest> CreateClient(CreateClientRequest request)
        {
            //mapear request -> Cliente
            var cliente = new Cliente
            {
                DNI = request.dni,
                Nombre = request.name,
                Apellido = request.lastname,
                Direccion = request.address,
                Telefono = request.phoneNumber
            };
            await _command.InsertClient(cliente);
            var r = new CreateClientRequest
            {
                dni = cliente.DNI,
                name = cliente.Nombre,
                lastname = cliente.Apellido,
                address = cliente.Direccion,
                phoneNumber = cliente.Telefono
            };
            return r;
        }
        public async Task<Cliente> GetClient(int clientId)
        {
            var c = await Task.Run (() => _query.GetClient(clientId));
            return c;
        }
        public async Task<List<Cliente>> GetClients()
        {
            var list = await Task.Run(() => _query.GetListClient());// error await
            return list;
        }
        public Task<Cliente> DeleteClient(int clientId)
        {
            throw new NotImplementedException();
        }
        public Task<Cliente> UpdateClient(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
