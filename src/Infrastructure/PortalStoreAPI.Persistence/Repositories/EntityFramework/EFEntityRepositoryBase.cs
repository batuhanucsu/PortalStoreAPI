using Microsoft.EntityFrameworkCore;
using PortalStoreAPI.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PortalStoreAPI.Application.Persistence.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, new()
         where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public Task DeleteAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                return context.SaveChangesAsync();
            }

        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    await context.Set<TEntity>().ToListAsync() :
                    await context.Set<TEntity>().Where(filter).ToListAsync();

            }
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            using (TContext context = new TContext())
            {
                var entity = await context.Set<TEntity>().FindAsync(Id);
                return entity;

            }
        }

        public Task UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                return context.SaveChangesAsync();

            }
        }
    }
}
