using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class AdvancedController : Controller
    {
        public IActionResult Index()
        {
            var header1 = Request.Headers["header1"];
            var header2 = Request.Headers["password"];

            if(header2 != "usjci")
            {
                return StatusCode(403);
            }
            return Ok("the headers are :" + header1 + " and  " + header2); ;
        }

        public IActionResult method2()
        {

            Response.Headers["header1"] = "This is my header from backend";
            Response.Headers["useKey"] = "1234";
            return Ok("check headers");
        }

        public IActionResult full()
        {
            // response header should contains status code, headers and body;

            var body = "This is my body";

            Response.Headers["header1"] = "this is my header";

            return StatusCode(250, body);

        }

     
    }
}
