using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return Ok("I am second controller and i am index function");
        }

        public IActionResult Data()
        {
            return Ok("I am second controller and i am data function");
        }


    }
}
