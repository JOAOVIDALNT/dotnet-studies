using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using di.Models;

namespace di.Services
{
    public class ClientRepository : IClientRepository
    {
        public List<Pedido> GetPedidos()
        {
            var pedidos = new List<Pedido>();
            
            pedidos.Add(new Pedido {PedidoId = 1001, ClientId = 2002});
            pedidos.Add(new Pedido {PedidoId = 3003, ClientId = 4004});

            return pedidos;
        }
    }
}