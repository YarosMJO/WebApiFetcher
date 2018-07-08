using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class SingleTodoController : Controller
    {
        // GET: SingleTodo
        public ActionResult Index(int id)
        {
            UserService service = new UserService();
            List<User> users = new List<User>();
            Todo todo = new Todo();
            if (ModelState.IsValid)
            {
                users = service.GetUsers()?.Result;
                todo = users.SelectMany(x => x.Todos).FirstOrDefault(x => x.Id == id);
            }
            return View(todo);
        }
    }
}