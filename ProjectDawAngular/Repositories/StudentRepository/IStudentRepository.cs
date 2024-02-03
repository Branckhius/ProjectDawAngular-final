using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories;
using ProjectDawAngular.Repositories.GenericRepository;
public interface IStudentRepository : IGenericRepository<Student>
{
    Task<List<Student>> GetAllWithInclude();
    Task<List<dynamic>> GetAllWithJoin();
    Task<Student> GetById(int id);
    Task<List<IGrouping<int, Student>>> GroupBy();
    Task<List<Student>> Where(int age);
    Task Update(int id, Student updatedStudent);
    Task<List<Student>> Delete(int id);
}