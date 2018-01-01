using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetVueSite.Pages.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private static Dictionary<string, Todo> todos = new Dictionary<string, Todo>();

        [HttpGet()]
        public IEnumerable<Todo> GetTodos()
        {
            return todos.Values;
        }

        [HttpPost()]
        public Todo AddTodo([FromBody]object model)
        {
            if (model != null && model is string)
            {
                Todo todo = new Todo();
                todo.Title = model.ToString();
                todo.Id = Guid.NewGuid();
                todos.Add(todo.Id.ToString(), todo);
                return todo;
            }
            else
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        public void DeleteTodo(string id)
        {           
            todos.Remove(id);
        }

        [HttpDelete("clear")]
        public void Clear()
        {
            todos.Clear();
        }
    }

    public class Todo
    {
        [JsonProperty(PropertyName= "id", DefaultValueHandling= DefaultValueHandling.Ignore)]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}