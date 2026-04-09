using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Ok("I am admin");
        }
    }
}
