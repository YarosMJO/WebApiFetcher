using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApiFetcher.Models;

namespace WebApiFetcher.Controllers
{
    public class UserController : Controller
    {
        // GET: User/GetUsers
        public ActionResult Index()
        {
            UserService service = new UserService();
            List<User> users = new List<User>();

            if (ModelState.IsValid)
            {
                users = service.GetUsers()?.Result;
            }
            return View(users);
        }
    }
}