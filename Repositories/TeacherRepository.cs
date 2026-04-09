using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using USCJCI.Data;
using USCJCI.Models;

namespace USCJCI.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly ApplicationDbContext _db;


        public TeacherRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task AddRow(Teacher obj)
        {
            await _db.Teachers.AddAsync(obj);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRow(int id)
        {
            Teacher ? teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null) {

                throw new KeyNotFoundException();
            }
            _db.Teachers.Remove(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Teacher>> getAllRows()
        {
            List<Teacher> rows = await _db.Teachers.ToListAsync();
            return rows; ;
        }

        public async Task<Teacher> GetRowById(int id)
        {
            Teacher? teacher = await _db.Teachers.FindAsync(id);
            if (teacher == null)
            {

                throw new KeyNotFoundException();
            }
            return teacher;
        }

        public async Task UpdateRow(Teacher obj)
        {
           _db.Teachers.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
