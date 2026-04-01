using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using USCJCI.Data;
using USCJCI.Models;

namespace USCJCI.Controllers
{
    public class ProductController : Controller
    {
        // CRUD
        // C Create
        // R Read (read all, read by id)
        // U Update
        // D Delete

        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext _c)
        {
            this.context= _c;
            
        }

        public IActionResult Index()
        {
            // SELECT * FROM PRODUCTS; 
            // I WANT TO RETRIEVE ALL EXISTING PRODUCTS
            List<Product> allProducts = context.Products.ToList();

            // SENDING DATA USING STRONGLY TYPED DATA
            return View(allProducts);
        }

        public IActionResult Show(int id)
        {

            if (id <= 0)
            {
                return StatusCode(400, "Enter  a valid id");
            }
            //I WANT TO RETREIVE A SPECIFIC PRODUCT BY HIS ID AND DISPLAY INFORMATION
            // SELECT * FROM PRODUCTS WHERE ID = ? ;

            Product product = context.Products.Find(id);

            if(null == product)
            {
                return NotFound();
            }

            // SENDING DATA USING WEAKLY TYPED DATA
            ViewBag.row = product;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Store(Product p)
        {


            if(p != null && p.Price == 10)
            {
                ModelState.AddModelError("Price", "the price should not be 10");
            }


            if (p != null && p.Description.Length < 3)
            {
                ModelState.AddModelError("Description", "the description should be at least 4 characters");
            }

            if (ModelState.IsValid)
            {
                // insert data
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create",p);


        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return StatusCode(400, "Enter  a valid id");
            }

            Product product = context.Products.Find(id);

            if (null == product)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product p)
        {
            
            context.Products.Update(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            Product product = context.Products.Find(id);
            if (null == product)
            {
                return NotFound();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
