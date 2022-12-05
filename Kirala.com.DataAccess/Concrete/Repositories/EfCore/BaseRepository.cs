using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Concrete.Repositories.EfCore
{
    public class BaseRepository<T, TContext> : IRepository<T>
        where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Create(T entity)
        {
            using (TContext context = new TContext())
            {
                var add = context.Entry(entity);
                add.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var delete = context.Entry(entity);
                delete.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteByFilter(Expression<Func<T, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var entity = await context.Set<T>().SingleOrDefaultAsync(filter);
                var deleteByFilter = context.Entry(entity);
                deleteByFilter.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? await context.Set<T>().ToListAsync()
                    : await context.Set<T>().Where(filter).ToListAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var update = context.Entry(entity);
                update.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

    }
}
