using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_app.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumProblem Problem { get; set; }
        public EnumSector Sector { get; set; }
        public string Description { get; set; }
    }
}