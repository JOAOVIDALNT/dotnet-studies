using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using di.Services;
using Microsoft.AspNetCore.Mvc;

namespace di.Controllers
{
    public class DemoDiController : Controller
    {
        private readonly IClientService _clientService;

        public DemoDiController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var pedidos = _clientService.GetPedidosCliente();
            return View(pedidos);
        }
    }
}