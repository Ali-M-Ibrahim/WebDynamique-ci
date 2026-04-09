using Microsoft.AspNetCore.Mvc;
using USCJCI.Services;

namespace USCJCI.Controllers
{
    public class DIController : Controller
    {
        private readonly Service1 _service;

        public DIController(Service1 s)
        {
            _service = s;
        }

        public IActionResult Index()
        {
            // Service1 myservice = new Service1(); 
            _service.myService1();
           
            return Ok("DI done");
        }

        public IActionResult Index2()
        {
            _service.myService1();
            return Ok("DI done 2");
        }
    }
}
