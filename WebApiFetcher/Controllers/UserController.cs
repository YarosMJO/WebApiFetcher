using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApiFetcher.Models;

namespace WebApiFetcher.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            UserService Service = new UserService();
            List<User> users = new List<User>();

            if (ModelState.IsValid)
            {
                users = Service.GetUsers();
            }
            return View(users);
        }
    }
}