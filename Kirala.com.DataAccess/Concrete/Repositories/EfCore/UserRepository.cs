using Kirala.com.DataAccess.Abstract;
using Kirala.com.DataAccess.Contexts.EntityFrameworkCore;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.DataAccess.Concrete.Repositories.EfCore
{
    public class UserRepository : BaseRepository<User, EfCoreDbContext>, IUserRepository
    {
    }
}
