using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly OrderContext _context;

    public OrderController(OrderContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();
        return Ok(order);
    }

    [HttpGet("GetOrderById/{id}")]
    public IActionResult GetById(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();
        
        return Ok(order);
    }

    [HttpPatch("StatusUpdate/{id}")]
    public IActionResult Update(int id, Status status)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
            return NotFound();
        if (order.Status == Status.AguardandoPagamento && status == Status.Enviado || status == Status.Entregue)
        {
            return BadRequest(new { Error = "O pedido não pode ser enviado ou entregue sem o pagamento aprovado" });
        }
        else if (order.Status == Status.PagamentoAprovado && status == Status.AguardandoPagamento || status == Status.Entregue)
        {
            return BadRequest(new { Error = "O Pagamento já foi aprovado e o pedido deve ser enviado" });
        }
        else if (order.Status == Status.Enviado && status != Status.Entregue)
        {
            return BadRequest(new { Error = "O Produto já está a caminho do destinatário" });
        }
        order.Status = status;
        _context.SaveChanges();
        return Ok(order);
    }
    
    
}