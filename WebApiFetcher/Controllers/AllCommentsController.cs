using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class AllCommentsController : Controller
    {
        // GET: AllComments
        public IActionResult Index()
        {
            AllCommentsService Service = new AllCommentsService();
            return View(Service.GetComments());
        }
    }
}