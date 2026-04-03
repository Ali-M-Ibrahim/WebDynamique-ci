using Microsoft.AspNetCore.Mvc;
using USCJCI.Data;
using USCJCI.Models;

namespace USCJCI.Controllers
{
    public class LinqController : Controller
    {
        private readonly ApplicationDbContext context;

        public LinqController(ApplicationDbContext _db)
        {

            context = _db;

        }

        public IActionResult Index()
        {
            // SELECT * FROM PRODUCTS
            List<Product> all = context.Products.ToList();
            return Ok(all);
        }

        public IActionResult Getbyid(int id)
        {
            // select * from products where id = ?;
            Product producti = context.Products.Find(id);
            return Ok(producti);
        }


        public IActionResult withcondition()
        {
            // SELECT * FROM PRODUCTS p WHERE p.PRICE > 10;

            var data = context.Products.Where(p => p.Price > 10);

            var data2 = from p in context.Products where p.Price > 10 select p;

            return Ok(data2);

        }

        public IActionResult multiplecondition()
        {
            // SELECT * FROM PRODUCTS WHERE ID > 2 AND PRICE > 20;

            var data = context.Products.Where(p => p.Id > 2).Where(p => p.Price >= 20);

            var data2 = from p in context.Products where p.Id > 2 where p.Price >= 20 select p ;

            return Ok(data2);

        }

        public IActionResult retrievefields()
        {
            // SELECT P.ID FROM PRODUCTS P WHERE P.ID > 2;
            var data = context.Products.Where(p => p.Id > 2).Select(p => p.Id);
            var data2 = from p in context.Products where p.Id > 2 select p.Id;

            // SELECT P.ID, P.NAME FROM PRODUCTS P WHERE P.ID > 2;
            var data3 = context.Products.Where(p => p.Id > 2).Select(p => new { p.Id, p.Name });
            var data4 = from p in context.Products where p.Id > 2 select new { p.Id, p.Name };


            return Ok(data3);
        }


        public IActionResult ordering()
        {
            // select * from products where id > 1 order by price asc;
            var data = context.Products.Where(p => p.Id > 1).OrderBy(p => p.Price);

            // select * from products where id > 1 order by price desc;
            var data2 = context.Products.Where(p => p.Id > 1).OrderByDescending(p => p.Price);

            // select * from products where id > 1 order by price asc;
            var data3 = from p in context.Products where p.Id > 1 orderby p.Price select p;

            // select * from products where id > 1 order by price desc;
            var data4 = from p in context.Products where p.Id > 1 orderby p.Price descending select p;


            return Ok(data4);
        }

        public IActionResult first()
        {
            // select * from products where id > 1 limit 1;
            var data = context.Products.Where(p => p.Id > 1).First();


            // select * from products where id > 1 limit 1;
            var data2 = context.Products.Where(p => p.Id > 1).FirstOrDefault();
            if(null == data2)
            {
                return Ok("no data found");
            }



            var data3 = (from p in context.Products where p.Id > 1 select p).First();
            var data4 = (from p in context.Products where p.Id > 1 select p).FirstOrDefault();
            return Ok(data4);

        }


        public IActionResult limit()
        {
            // select * from products where id > 1 limit 5;
            var data = context.Products.Where(p => p.Id > 1).Take(3);

            var data2 = context.Products.Where(p => p.Id > 1).Skip(2);
            return Ok(data2);
        }

        public IActionResult group()
        {
            // select * from products group by price;
            var data = context.Products.GroupBy(p => p.Price);

            var data2 = from p in context.Products group p by p.Price;
            return Ok(data2);
        }

        public IActionResult anyall()
        {
            var data = context.Products.Any(p => p.Price > 10);
            var data2 = context.Products.All(p => p.Price > 10);
            return Ok(data2);

;       }


        public IActionResult stats()
        {
            var countProduct = context.Products.Where(p => p.Id > 1).Count();
            var MaxProductPrice = context.Products.Where(p => p.Id > 1).Max(p=>p.Price);
            var MinProductPrice = context.Products.Where(p => p.Id > 1).Min(p => p.Price);
            var SumProductPrice = context.Products.Where(p => p.Id > 1).Sum(p => p.Price);
            return Ok(SumProductPrice);
        }


    }
}
