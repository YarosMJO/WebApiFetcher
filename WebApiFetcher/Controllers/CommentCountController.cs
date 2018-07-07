using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Models;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class CommentCountController : Controller
    {

        // GET: ComentCount
        public ActionResult Index()
        {
            return View();
        }

        // POST: CommentStat
        [HttpPost]
        public ActionResult Index(int? userId)
        {
            List<Post> posts = new List<Post>();
            CommentCountService service = new CommentCountService();

            if (ModelState.IsValid)
            {
                posts = service.GetCommentsCountAsync(userId).Result;
            }

            return View(posts);
        }
    }
}