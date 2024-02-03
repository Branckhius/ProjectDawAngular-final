using ProjectDawAngular.Models;
using ProjectDawAngular.Repositories.GenericRepository;
using ProjectDawAngular.Repositories;
namespace ProjectDawAngular.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> FindByUsername(string username);


        Task<List<User>> FindAll();

        Task<List<User>> FindAllActive();
        Task<User> GetById(int userId);
    }
}
