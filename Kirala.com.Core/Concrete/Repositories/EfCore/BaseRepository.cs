using Kirala.com.DataAccess.Abstract;
using Kirala.com.DataAccess.Contexts.EntityFrameworkCore;
using Kirala.com.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Concrete.Repositories.EfCore
{
    public class BaseRepository<T, TContext> : IRepository<T>
        where T : class, IEntity, new()
        where TContext : EfCoreDbContext, new()
    {
        public async Task Create(T entity)
        {
            using (TContext context = new TContext())
            {
                var add = context.Entry(entity);
                add.State = EntityState.Added;
                context.SaveChangesAsync();
            }
        }

        public async Task DeleteByFilter(Func<T, bool> filter)
        {
            using (TContext context = new TContext())
            {
                var delete = context.Entry(Get(filter));
                delete.State = EntityState.Deleted;
                context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(Func<T, bool> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(filter);
            }
        }

        public async Task<IEnumerable<T>> GetAllByFilter(Func<T, bool> filter)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<T>().Where(filter)
                    : context.Set<T>();
            }
        }

        public async Task Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var update = context.Entry(entity);
                update.State = EntityState.Modified;
                context.SaveChangesAsync();
            }
        }
    }
}
