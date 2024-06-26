using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Context;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context) // INJEÇÃO DE DEPENDENCIA
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges(); // PARA TODOS, COM EXCESSÃO DO GET SE CHAMA O SAVECHANGES PARA ATUALIZAR O DB
            return CreatedAtAction(nameof(GetById), new {id = contato.Id}, contato);
            // o response header retorna a location da inserção
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult GetByName(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));
            
            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            {
                return NotFound();
            }
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }

    
        

    }
}