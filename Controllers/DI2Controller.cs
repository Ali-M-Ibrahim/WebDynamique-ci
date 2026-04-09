using Microsoft.AspNetCore.Mvc;
using USCJCI.Services;

namespace USCJCI.Controllers
{
    public class DI2Controller : Controller
    {
        public IActionResult Index()
        {
            return Ok("i am index 1");
        }

        public IActionResult Index2(Service1 myservice)
        {
            myservice.myService1();

            return Ok("I am inedx2");
        }


    }
}
