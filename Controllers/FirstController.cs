using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return Ok("I am firsrt controller and i am index function");
        }

        public IActionResult Content() {
            return Ok("I am first controller and i am content function");
        }

        public IActionResult method3()
        {
            return StatusCode(201, "The data is saved successfully in the database");
            //return StatusCode(555, "this is my data");
            //return StatusCode(500);
        }

        public IActionResult method4()
        {
            return Content("This is my data");
        }

        public IActionResult method5()
        {
            // return StatusCode(404)
            return NotFound();
        }

        public IActionResult method6()
        {
            // return StatusCode(400)
            return BadRequest();
        }

        public IActionResult method7() {

            return RedirectToAction("method6");
        }

        public IActionResult Details(int id)
        {
            return Ok("The paramter is" + id);
        }

        public IActionResult Details2(int id, string name)
        {
            return Ok("the parameters are: " + id + " and " + name);
        }

        public IActionResult more(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }else if(id == 1)
            {
                return NotFound();
            }
            else
            {
                return Ok("the data is: " + id);
            }
        }


       



    }
}
