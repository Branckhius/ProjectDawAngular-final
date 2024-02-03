using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
using System.Collections.Generic;
namespace ProjectDawAngular.Repositories.ProfessorRepository
{

    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(Lab4Context lab4Context) : base(lab4Context) { }
        // Adaugă metode specifice pentru Professor aici, dacă este necesar
        public async Task<Professor> GetById(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task Update(int id, Professor professor)
        {
            var existingProfessor = await _table.FindAsync(id);

            if (existingProfessor == null)
                throw new ArgumentException("Professor not found");

            // Actualizăm proprietățile necesare
            existingProfessor.Name = professor.Name;
            existingProfessor.DepartmentId = professor.DepartmentId;

            _table.Update(existingProfessor);
            await SaveAsync();
        }
        public async Task<List<Professor>> Delete(int professorId)
        {
            var professor = await _table.FindAsync(professorId);

            if (professor != null)
            {
                _table.Remove(professor);
                await SaveAsync();
            }

            return await GetAll();
        }


    }


}