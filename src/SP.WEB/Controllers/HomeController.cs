using Microsoft.AspNet.Mvc;

namespace SP.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {

            return View();
        }
        

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
