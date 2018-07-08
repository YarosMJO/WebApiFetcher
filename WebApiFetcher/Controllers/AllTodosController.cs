using Microsoft.AspNetCore.Mvc;
using WebApiFetcher.Services;

namespace WebApiFetcher.Controllers
{
    public class AllTodosController : Controller
    {
        // GET: AllTodos
        public IActionResult Index()
        {
            AllTodosService Service = new AllTodosService();
            return View(Service.GetTodos());
        }
    }
}