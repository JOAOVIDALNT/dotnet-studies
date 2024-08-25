using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers;

public class HomeController : Controller 
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(); // o nome HomeController define que a informaçao deve ser buscada na View Home e o nome do método define que o arquivo é o Index.cshtml
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
