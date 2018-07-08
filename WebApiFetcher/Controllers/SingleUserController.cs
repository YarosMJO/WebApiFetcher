using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class SingleUserController : Controller
    {
        // GET: SingleUser
        public ActionResult Index(int id)
        {
            UserService service = new UserService();
            User user = new User();
            if (ModelState.IsValid)
            {
                user = service.GetUsers()?.Result.FirstOrDefault(y => y.Id == id);
            }
            return View(user);
         }
    }
}