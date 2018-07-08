using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApiFetcher.Models;

namespace WebApiFetcher.Services
{
    public class SinglePostController : Controller
    {
        public ActionResult Index(int id)
        {
            UserService service = new UserService();
            List<User> users = new List<User>();
            Post post = new Post();
            if (ModelState.IsValid)
            {
                users = service.GetUsers()?.Result;
                post = users.SelectMany(x => x.Posts).FirstOrDefault(x => x.Id == id);
            }
            return View(post);
        }
    }
}