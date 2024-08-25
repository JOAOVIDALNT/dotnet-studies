using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
        
    }
    
    public DbSet<Order> Orders { get; set; }

}