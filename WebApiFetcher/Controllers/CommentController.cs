using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiFetcher.Models;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // POST: Comment
        [HttpPost]
        public ActionResult Index(int? userId)
        {
            List<Comment> comments = new List<Comment>();
            CommentService service = new CommentService();

            if (ModelState.IsValid)
            {
                comments = service.GetComments(userId);
            }

            return View(comments);
        }
    }
}