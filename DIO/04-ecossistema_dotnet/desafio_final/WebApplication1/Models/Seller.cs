using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Seller
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}