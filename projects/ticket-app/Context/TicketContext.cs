using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ticket_app.Models;

namespace ticket_app.Context
{
    public class TicketContext : DbContext
    {

        public TicketContext(DbContextOptions<TicketContext> options) : base(options){}

        public DbSet<Ticket> Ticket { get; set; }
        
    }
}