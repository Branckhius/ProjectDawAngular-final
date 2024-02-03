using ProjectDawAngular.Data;
using ProjectDawAngular.Helpers.Extensions;
using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectDawAngular.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Lab4Context _dbContext; // Adăugați membrul de date pentru DbContext

        public UserRepository(Lab4Context lab4Context) : base(lab4Context)
        {
            _dbContext = lab4Context; // Asigurați-vă că atribuiți _dbContext corect aici
        }

        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<User>> FindAllActive()
        {
            return await _table.GetActiveUser().ToListAsync();
        }

        public async Task<User> FindByUsername(string username)
        {
            return (await _table.FirstOrDefaultAsync(u => u.Username.Equals(username)))!;
        }

        public async Task<User> GetById(int userId)
        {
            // Utilizați _dbContext aici pentru a obține utilizatorul din baza de date
            return await _table.AsNoTracking().FirstOrDefaultAsync(pd => pd.Id == userId);
        }
    }
}
