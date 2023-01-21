using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller // mvc é mais simples
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
    }
}