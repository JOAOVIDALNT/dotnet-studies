using Microsoft.EntityFrameworkCore;
using MyTable_API.Models;

namespace MyTable_API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
