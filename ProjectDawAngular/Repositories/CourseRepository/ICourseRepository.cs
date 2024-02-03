using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetAllWithInclude();
        Task<List<dynamic>> GetAllWithJoin();
        Task<Course> GetById(int id);
        Task Update(int id, Course updatedCourse);
        Task<List<Course>> Delete(int id);
}

