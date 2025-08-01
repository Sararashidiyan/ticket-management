using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Common;

namespace Ticketing.Infrustructure.Repositories
{
    public class BaseRepository<TContext, TKey, T>(TContext dbContext) : IRepository<TKey, T>
    where T : class, IAggregateRoot
       where TContext : AppDbContext
    {
        public async Task CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
