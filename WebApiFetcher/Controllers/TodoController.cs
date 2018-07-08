using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Models;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public IActionResult Index()
        {
            return View();
        }
        // POST: Todo
        [HttpPost]
        public IActionResult Index(int? userId)
        {
            TodoService Service = new TodoService();
            List<Todo> todos = new List<Todo>();

            if (ModelState.IsValid)
            {
                if (userId == null){ return NotFound(); }

                todos = Service.GetTodos(userId);
              
            }
            return View(todos);
        }
    }

}