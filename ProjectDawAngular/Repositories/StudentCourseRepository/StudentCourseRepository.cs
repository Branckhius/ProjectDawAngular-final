using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
namespace ProjectDawAngular.Repositories.StudentCourseRepository
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(Lab4Context lab4Context) : base(lab4Context) { }
        // Adaugă metode specifice pentru StudentCourse aici, dacă este necesar
    }
}
