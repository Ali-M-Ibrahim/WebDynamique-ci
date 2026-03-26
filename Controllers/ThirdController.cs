using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    [Route("custom")]
    public class ThirdController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return Ok("I am third controller and index function");
        }

        [Route("method2")]
        public IActionResult Method2()
        {
            return Ok("I am third controller and method 2 function");

        }
        [Route("method3/{id}")]
        public IActionResult Method3(int id)
        {
            return Ok("I am third controller and method 3 function: " + id);

        }
        [Route("/custom-method-4")]
        public IActionResult method4()
        {
            return Ok("I am third controller and method 4 function");

        }
    }
}
