using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        Task<T> Get(Func<T,bool> filter);
        Task<IEnumerable<T>> GetAllByFilter(Func<T, bool> filter);
        Task Create(T entity);
        Task Update(T entity);
        Task DeleteByFilter(Func<T,bool> filter);

    }
}
