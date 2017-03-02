using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreExample.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreExample.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            _todoItems = todoItems;
        }

        private readonly ITodoRepository _todoItems;

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {

            return _todoItems.GetAll();
        }

        [HttpGet("{id}", Name ="GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _todoItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            _todoItems.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _todoItems.Find(id);
            if(todo == null)
            {
                return NotFound();
            }

            _todoItems.Remove(id);
            return new NoContentResult();
        }
    }
}
