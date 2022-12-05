using Kirala.com.Business.Utilities.JWT;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Abstract
{
    public interface IJwtHelper 
    {
        AccessToken CreateToken(User user);
    }
}
