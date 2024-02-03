using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;

namespace ProjectDawAngular.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly Lab4Context _context;

        public StudentRepository(Lab4Context lab4Context) : base(lab4Context)
        {
            _context = lab4Context;
        }
        public async Task<Student> GetById(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Student>> GetAllWithInclude()
        {
            return await _table.Include(s => s.StudentCourses).ToListAsync();
        }
        public async Task<List<IGrouping<int, Student>>> GroupBy()
        {
            return await _table.GroupBy(s => s.Age).ToListAsync();
        }
        public async Task<List<Student>> Where(int age)
        {
            return await _table.Where(s => s.Age == age).ToListAsync();
        }
        public async Task Update(int id, Student updatedStudent)
        {
            var existingStudent = await _table.FindAsync(id);

            if (existingStudent == null)
                throw new ArgumentException("Student not found");

            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;

            _table.Update(existingStudent);
            await SaveAsync();
        }

        public async Task<List<Student>> Delete(int id)
        {
            var studentToDelete = await _table.FindAsync(id);

            if (studentToDelete != null)
                _table.Remove(studentToDelete);

            return await _table.ToListAsync();
        }
        public async Task<List<dynamic>> GetAllWithJoin()
        {
            var query = from student in _table
                        join studentCourse in _context.Set<StudentCourse>() on student.Id equals studentCourse.StudentId
                        join course in _context.Set<Course>() on studentCourse.CourseId equals course.Id
                        select new { Student = student, Course = course };

            return await query.ToListAsync<dynamic>();
        }
    }
}
