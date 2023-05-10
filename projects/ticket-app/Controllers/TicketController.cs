using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ticket_app.Models;
using ticket_app.Context;

namespace ticket_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly TicketContext _context;

        public TicketController(TicketContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = ticket.Id}, ticket);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var ticket = _context.Ticket.Find(id);

            if(ticket == null) 
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet]
        public IActionResult GetAll() {
            var ticket = _context.Ticket.ToList();
            return Ok(ticket);
        }
    }
}