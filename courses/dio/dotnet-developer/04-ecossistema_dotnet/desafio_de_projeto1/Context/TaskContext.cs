using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using desafio_de_projeto1.Models;

namespace desafio_de_projeto1.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}