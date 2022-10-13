using Application.Interfaces;
using Domain.Entities;
using Domain.Models;

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
        
        //1.
        public async Task<CreateClientResponse> CreateClient(CreateClientRequest request)
        {
            var cliente = new Cliente
            {
                DNI = request.dni,
                Nombre = request.name,
                Apellido = request.lastname,
                Direccion = request.address,
                Telefono = request.phoneNumber
            };
            await _command.InsertClient(cliente);
            var r = new CreateClientResponse
            {
                id = cliente.ClienteId
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
            var list = await Task.Run(() => _query.GetListClient());
            return list;
        }
    }
}
