using System.Linq;
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
            UserService Service = new UserService();
            User user = new User();
            if (ModelState.IsValid)
            {
                user = Service.UsersList.FirstOrDefault(y => y.Id == id);
            }
            return View(user);
         }
    }
}