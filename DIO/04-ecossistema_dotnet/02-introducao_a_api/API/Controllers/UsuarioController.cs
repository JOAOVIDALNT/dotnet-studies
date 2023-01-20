using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    { // A PALAVRA "CONTROLLER" DE UsuarioController É IGNORADA NO ENDPOINT
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult ObterDataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar(string nome)
        {
            var mensagem = $"Olá {nome}, seja bem vindo(a)";
            return Ok(new {mensagem});
        }
        // O NOME VIRA UM PARÂMETRO OBRIGATORIO NO SWAGGER
        // https://localhost:7015/Usuario/Apresentar/João -> basta acessar o endpoint com o nome desejado
    }
}