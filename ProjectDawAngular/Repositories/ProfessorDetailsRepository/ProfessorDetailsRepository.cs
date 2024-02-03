using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
namespace ProjectDawAngular.Repositories.ProfessorDetailsRepository
{
    public class ProfessorDetailsRepository : GenericRepository<ProfessorDetails>, IProfessorDetailsRepository
    {
        public ProfessorDetailsRepository(Lab4Context lab4Context) : base(lab4Context) { }
        public async Task<ProfessorDetails> GetById(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(pd => pd.Id == id);
        }
        public async Task Update(int professorDetailsId, ProfessorDetails professorDetails)
        {
            var existingProfessorDetails = await GetById(professorDetailsId);

            if (existingProfessorDetails == null)
            {

                return;
            }


            existingProfessorDetails.OfficeLocation = professorDetails.OfficeLocation;
            existingProfessorDetails.ProfessorId = professorDetails.ProfessorId;

            Update(existingProfessorDetails);

            await SaveAsync();
        }
        public async Task<List<ProfessorDetails>> Delete(int professorId)
        {
            var professorDetails = await _table.FindAsync(professorId);

            if (professorDetails != null)
            {
                _table.Remove(professorDetails);
                await SaveAsync();
            }

            return await GetAll();
        }
    }
}