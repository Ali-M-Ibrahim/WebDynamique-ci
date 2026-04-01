using Microsoft.AspNetCore.Mvc;
using USCJCI.Models;

namespace USCJCI.Controllers
{
    public class PartialviewController : Controller
    {
        public IActionResult Index()
        {

            var list = new List<Person>()
            {
                new Person() { Id=1, Name="Ali Ibrahim", Image="https://www.w3schools.com/howto/img_avatar.png", Title="Maitre de conference" },
                new Person() { Id=2, Name="Zahraa Baderdine", Image="https://static.vecteezy.com/system/resources/thumbnails/004/899/680/small/beautiful-blonde-woman-with-makeup-avatar-for-a-beauty-salon-illustration-in-the-cartoon-style-vector.jpg", Title="Etudiante" },
                new Person() { Id=3, Name="Hussein", Image="https://www.w3schools.com/howto/img_avatar.png", Title="Etudiant" },

            };

            return View(list);
        }
    }
}
