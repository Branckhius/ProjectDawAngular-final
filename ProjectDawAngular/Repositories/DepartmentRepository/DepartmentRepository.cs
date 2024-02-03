using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Repositories.GenericRepository;
namespace ProjectDawAngular.Repositories.DepartmentRepository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(Lab4Context lab4Context) : base(lab4Context) { }
        // Adaugă metode specifice pentru Department aici, dacă este necesar\
        public async Task<Department> GetById(int id)
        {
            return await _table.FindAsync(id);
        }
        public async Task Update(int id, Department entity)
        {
            var existingDepartment = await _table.FindAsync(id);

            if (existingDepartment != null)
            {
                existingDepartment.Name = entity.Name;
                existingDepartment.Location = entity.Location;

                _table.Update(existingDepartment);
            }
        }

        public async Task<List<Department>> Delete(int id)
        {
            var departmentToDelete = await _table.FindAsync(id);

            if (departmentToDelete != null)
                _table.Remove(departmentToDelete);

            return await _table.ToListAsync();
        }
    }
}