using Microsoft.AspNetCore.Mvc;
using USCJCI.Models;

namespace USCJCI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            // will check a file inside views/student/index
            return View();
        }

        public IActionResult Privacy()
        {
            // will check a file inside views/student/privacy
            return View();
        }

        public IActionResult About()
        {
            // same folder different page
            return View("Default");
        }

        public IActionResult Home()
        {
            // different folder different 
            // relative path
            // i want to return the index file inside test folder
            return View("../Test/index");
        }

        public IActionResult Contact()
        {
            // absolute path
            // i want to return the index file inside test folder
            return View("views/test/index.cshtml");
        }


        public IActionResult Show()
        {
            var obj = new Student()
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ibrahim"
            };
            // To pass data to view using Strongly Typed Data
            return View(obj);
        }

        public IActionResult Show2()
        {
            var obj = new Student()
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ibrahim"
            };

            return View("Display", obj);
        }

        public IActionResult list()
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

            var s3 = new Student()
            {
                Id = 3,
                FirstName = "Zahraa",
                LastName = "BaderDine"
            };

            var list = new List<Student>();
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);

            return View(list);

        }

        public IActionResult Room()
        {
            var list = new List<Student>();

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

            var s3 = new Student()
            {
                Id = 3,
                FirstName = "Zahraa",
                LastName = "BaderDine"
            };

            var c1 = new Course()
            {
                Id = 1,
                Code = "C001",
                Name = "Web Dynamique"
            };

            list.Add(s1);
            list.Add(s2);
            list.Add(s3);

            var room = new Room()
            {

                course = c1,
                students = list
            };
            return View(room);

        }

        public IActionResult Show3()
        {
            //Weakly Typed data

            var obj = new Student()
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ibrahim"
            };
            ViewData["student"] = obj;
            ViewData["Title"] = "Title of the page";
            ViewData["Date"] = "27/03/2026";
            return View();
        }

        public IActionResult Show4()
        {
            //Weakly Typed data

            var obj = new Student()
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ibrahim"
            };
            ViewBag.student = obj;
            ViewBag.title = "Title of the page";
            ViewBag.date = "27/03/2026";
            return View();
        }


        public IActionResult mix()
        {
            ViewData["title"] = "This is the title of the page";
            ViewData["date"] = "27/03/2026";

            var s3 = new Student()
            {
                Id = 3,
                FirstName = "Zahraa",
                LastName = "BaderDine"
            };

            var c1 = new Course()
            {
                Id = 1,
                Code = "C001",
                Name = "Web Dynamique"
            };

            ViewBag.student = s3;
            return View(c1);

        }

    }
}
