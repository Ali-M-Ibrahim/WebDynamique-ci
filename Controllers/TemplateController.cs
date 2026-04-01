using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
