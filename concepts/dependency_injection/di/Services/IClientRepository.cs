using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using di.Models;

namespace di.Services
{
    public interface IClientRepository
    {
        List<Pedido> GetPedidos();
    }
}