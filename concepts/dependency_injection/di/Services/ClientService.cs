using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using di.Models;

namespace di.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public List<Pedido> GetPedidosCliente()
        {
            return _clientRepository.GetPedidos();
        }
    }
}