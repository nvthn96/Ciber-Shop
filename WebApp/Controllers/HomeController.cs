using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Order");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
