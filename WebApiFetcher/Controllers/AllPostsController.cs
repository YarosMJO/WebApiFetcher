using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class AllPostsController : Controller
    {
        // GET: AllPosts
        public IActionResult Index()
        {
            AllPostsService Service = new AllPostsService();
            return View(Service.GetPosts());
        }
    }
}