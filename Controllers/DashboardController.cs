using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace USCJCI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;


        public DashboardController(UserManager<IdentityUser> u)
        {
            _userManager = u;
        }
        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            return Content("The connected user id is: " + userId);
        }


        [AllowAnonymous]
        public IActionResult contact()
        {
            return Ok("ok");
        }
    }
}
