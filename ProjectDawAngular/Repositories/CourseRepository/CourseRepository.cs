using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;

namespace ProjectDawAngular.Repositories.CourseRepository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly Lab4Context _context;

        public CourseRepository(Lab4Context lab4Context) : base(lab4Context)
        {
            _context = lab4Context;
        }

        public async Task<List<Course>> GetAllWithInclude()
        {
            return await _table.Include(c => c.Professor).Include(c => c.StudentCourses).ToListAsync();
        }

        public async Task<List<dynamic>> GetAllWithJoin()
        {
            var query = from course in _table
                        join professor in _context.Set<Professor>() on course.ProfessorId equals professor.Id
                        select new { Course = course, Professor = professor };

            return await query.ToListAsync<dynamic>();
        }
        public async Task<Course> GetById(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task Update(int id, Course updatedCourse)
        {
            var existingCourse = await GetById(id);

            if (existingCourse == null)
            {
                throw new ArgumentException("Course not found", nameof(id));
            }

            existingCourse.Title = updatedCourse.Title;
            existingCourse.Credits = updatedCourse.Credits;
            existingCourse.ProfessorId = updatedCourse.ProfessorId;

            await SaveAsync();
        }
        public async Task<List<Course>> Delete(int id)
        {
            var courseToDelete = await _table.FindAsync(id);
            if (courseToDelete == null)
            {
                return null; 
            }

            _table.Remove(courseToDelete);
            await SaveAsync();

            return await GetAll(); 
        }
    }
}
