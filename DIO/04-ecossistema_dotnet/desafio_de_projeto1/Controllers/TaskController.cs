using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using desafio_de_projeto1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using desafio_de_projeto1.Models;

namespace desafio_de_projeto1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return NotFound();
            
            return Ok(task);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var task = _context.Tasks.ToList();
            return Ok(task);
        }
        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var task = _context.Tasks.Where(x => x.Date.Date == date.Date);
            return Ok(task);
        }

        [HttpGet("GetBtStatus")]
        public IActionResult GetByStatus(EnumTaskStatus status)
        {
            var task = _context.Tasks.Where(x => x.Status == status);
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            if (task.Date == DateTime.MinValue)
                return BadRequest(new {Error = "Date can't be empty"});

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.Task task)
        {
            var taskdb = _context.Tasks.Find(id);
            if (taskdb == null)
                return NotFound();
            if (task.Date == DateTime.MinValue)
                return BadRequest(new {Error = "Date can't be empty"});

            _context.Tasks.Add(taskdb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
                return NotFound();
            
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}