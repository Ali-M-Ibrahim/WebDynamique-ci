using Microsoft.AspNetCore.Mvc;
using USCJCI.Models;
using USCJCI.Repositories;

namespace USCJCI.Controllers
{
    public class TeacherController : Controller
    {

        private readonly IRepository<Teacher> _repo;

        public TeacherController(IRepository<Teacher> i)
        {
            _repo = i;
        }


        public async Task<IActionResult> Index()
        {
            List<Teacher> all = await _repo.getAllRows();
            return View(all);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Store(Teacher teacher) { 
        
            await _repo.AddRow(teacher);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> View(int id)
        {
            Teacher row = await _repo.GetRowById(id);
            return View(row);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Teacher row = await _repo.GetRowById(id);
            return View(row);
        }

        public async Task<IActionResult> Update(Teacher teacher)
        {

            await _repo.UpdateRow(teacher);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _repo.DeleteRow(id);
            return RedirectToAction("Index");
        }




    }
}
