using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class FourthController : Controller
    {
        public IActionResult Index()
        {
            return Ok("I am controller number 4 and i am index function");
        }

        [Route("my-custom-route")]
        public IActionResult Method2()
        {
            return Ok("i am controller number 4 and i am method2 function");
        }
    }
}
