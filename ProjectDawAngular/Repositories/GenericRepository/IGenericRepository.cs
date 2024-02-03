using ProjectDawAngular.Models.Base;
using ProjectDawAngular.Repositories.GenericRepository;
namespace ProjectDawAngular.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Get all data
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Add(TEntity entity);
        // Create data
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);

        void CreateRange(IEnumerable<TEntity> entities);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        // Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        // Delete 
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // Find
        TEntity GetById(int id);
        Task<TEntity> FindByIdAsync(int id);


        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
