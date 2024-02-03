using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories;
using ProjectDawAngular.Repositories.GenericRepository;
public interface IProfessorDetailsRepository : IGenericRepository<ProfessorDetails>
{
    Task<ProfessorDetails> GetById(int id);
    Task Update(int professorDetailsId, ProfessorDetails professorDetails);
    Task<List<ProfessorDetails>> Delete(int professorId);
}
