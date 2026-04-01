using Microsoft.AspNetCore.Mvc;
using USCJCI.Models;


namespace USCJCI.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            var secret = Request.Headers["secret"];
            if(secret == "123")
            {
                var s1 = new Student()
                {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Doe"
                };

                var s2 = new Student()
                {
                    Id = 2,
                    FirstName = "Jaafar",
                    LastName = "Siklawi"
                };

                var list = new List<Student>();
                list.Add(s1);
                list.Add(s2);

                return StatusCode(202, list);
            }
            else
            {
                return StatusCode(403);
            }
            
        }

        public IActionResult Single()
        {
            Response.Headers["number_of_data"] = "1";
            var s1 = new Student()
            {
                Id = 1,
                FirstName = "Joe",
                LastName = "Doe"
            };
            return Ok(s1);

        }

        [HttpPost]
        public IActionResult Create( [FromBody] Student student)
        {
            return Ok(student);
        }
    }
}
