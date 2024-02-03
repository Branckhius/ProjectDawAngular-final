using Microsoft.EntityFrameworkCore;
using ProjectDawAngular.Data;
using ProjectDawAngular.Models.Base;
using ProjectDawAngular.Repositories.GenericRepository;

namespace ProjectDawAngular.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Lab4Context _lab4Context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(Lab4Context lab4Context)
        {
            _lab4Context = lab4Context;
            _table = _lab4Context.Set<TEntity>();
        }
        public async Task<List<TEntity>> Add(TEntity entity)
        {
            await _table.AddAsync(entity);
            await SaveAsync();
            return await GetAll();
        }

        // Get all
        public async Task<List<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }


        // Create
        public void Create(TEntity entity)
        {
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        // Update

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        // Delete

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        // Find
        public TEntity GetById(int id)
        {
            return _table.Find(id);
        }


        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        // Save
        public bool Save()
        {
            return _lab4Context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _lab4Context.SaveChangesAsync() > 0;
        }
    }
}
