using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Interfaces.Repository
{
    public interface IEntityRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetByIdAsync(int Id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
