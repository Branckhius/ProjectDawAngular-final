using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories;
using ProjectDawAngular.Repositories.GenericRepository;
public interface IDepartmentRepository : IGenericRepository<Department>
{
        Task<Department> GetById(int id);
        Task Update(int id, Department entity);
        Task<List<Department>> Delete(int id);
}
