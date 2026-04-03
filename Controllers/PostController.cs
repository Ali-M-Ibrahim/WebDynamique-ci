using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USCJCI.Data;
using USCJCI.Models;

namespace USCJCI.Controllers
{
    public class PostController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext _db)
        {
            _context= _db;
            
        }
        public async Task<IActionResult> Index()
        {
            // SELECT * FROM POSTS;
            List<Post> data = await _context.Posts.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Store(Post post) {

            if(post !=null && post.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The length should be 3");
            }
            if (ModelState.IsValid)
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("Create", post);


        }

        public async Task<IActionResult> View(int ? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }

            Post ? post = await _context.Posts.FindAsync(id);

            if(post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public async Task<IActionResult> Edit(int ? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Post? post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);

        }



        public async Task<IActionResult> Update(Post post)
        {
            if (post != null && post.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The length should be 3");
            }
            if (ModelState.IsValid)
            {
                // method 1 
          
                _context.Posts.Update(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");


                // method 2
                //Post? ExistingPost = await _context.Posts.FindAsync(post.Id);
                //ExistingPost.Title = "TEST -" + post.Title;
                //ExistingPost.Description = post.Description;
                //_context.Posts.Update(ExistingPost);
                //await _context.SaveChangesAsync();
                //return RedirectToAction("Index");
            }

            return View("Edit", post);

        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            Post? post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


 }
}
