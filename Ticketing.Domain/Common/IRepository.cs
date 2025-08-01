using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Domain.Common;

namespace Ticketing.Infrustructure.Repositories
{
    public interface IRepository<TKey,T> where T :IAggregateRoot
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
