using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Models;
using WebCoreApi.Services;

namespace WebApiFetcher.Controllers
{
    public class PostStructController : Controller
    {
        // GET: PostStruct
        public ActionResult Index()
        {
            return View();
        }

        // POST: PostStruct
        [HttpPost]
        public ActionResult Index(int? userId)
        {
            PostService Service = new PostService();
            PostStruct post = null;

            if (ModelState.IsValid)
            {
                post = Service.GetPostStructure(userId);
            }

            return View(post);
        }
    }
}