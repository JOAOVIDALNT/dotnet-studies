using System.Runtime.CompilerServices;

namespace WebApplication1.Models;

public class Order
{
    public int Id { get; set; }
    public Seller Seller { get; set; }
    public DateTime Date { get; set; }
    public List<Product> Products { get; set; }
    public Status Status { get; set; }
    
}