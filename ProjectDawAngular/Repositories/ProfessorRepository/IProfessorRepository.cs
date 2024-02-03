using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
using System.Collections.Generic;
using ProjectDawAngular.Repositories;
public interface IProfessorRepository : IGenericRepository<Professor>
    {
    Task<Professor> GetById(int id);
    Task Update(int id, Professor entity);
    Task<List<Professor>> Delete(int professorId);
}

