using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using villa_app_api.Models;

namespace villa_app_api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Villa> Villas {get; set;}
        
    }
}