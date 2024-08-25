using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using villa_app_utility;
using villa_app_web.Models.Dtos;
using villa_app_web.Models.Entities;
using villa_app_web.Services.IServices;

namespace villa_app_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> list = new();

            var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(Details.SessionToken));
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}