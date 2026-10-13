using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Repositories;
using TaskFlow.Insfrastructure.Data;

namespace TaskFlow.Insfrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TenantDbContext _tenantDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TenantDbContext tenant)
        {
            _tenantDbContext = tenant;
            _dbSet = _tenantDbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
                _dbSet.Update(entity);
            
        }
        public async Task DeleteAsync(Guid id)
        {
            var res = await _dbSet.FindAsync(id);
            if(res != null)
            {
                _dbSet.Remove(res);
            }
        }
        public async Task SaveChangesAsync()
        {
           await _tenantDbContext.SaveChangesAsync();   
        }
    }
}
