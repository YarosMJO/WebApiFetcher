using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Models;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class CommentStructController : Controller
    {

        // GET: CommentStruct
        public ActionResult Index()
        {
            return View();
        }

        // POST: CommentStruct
        [HttpPost]
        public ActionResult Index(int? userId)
        {
            CommentStruct commentStruct = null;
            CommentStructService service = new CommentStructService();

            if (ModelState.IsValid)
            {
                commentStruct = service.GetCommentStructureAsync(userId).Result;
            }

            return View(commentStruct);
        }

    }
}