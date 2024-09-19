using blazor_crud.Domain;
using Microsoft.EntityFrameworkCore;

namespace blazor_crud.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
    }
}
