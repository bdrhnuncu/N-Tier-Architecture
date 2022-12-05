using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task Create(T entity);
        Task Update(T entity);
        Task DeleteByFilter(Expression<Func<T, bool>> filter);
        Task Delete(T entity);
    }
}
