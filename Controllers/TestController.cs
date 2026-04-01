using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello CLass");
        }
    }
}
