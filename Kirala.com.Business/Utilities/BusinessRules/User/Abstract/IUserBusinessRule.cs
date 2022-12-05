using Kirala.com.Business.Utilities.Results.Abstract;
using U=Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.BusinessRules.User.Abstract
{
    public interface IUserBusinessRule
    {
        public Task<U.User> FindUser(string name, string password);
        public Task<IResult> UserRegisterCheck(string userName, string phone, string email);
        public Task<IResult> UserLoginCheck(string userName, string password);
        public Task<IResult> UserExistCheck(string userName, string phone, string email);
        public Task<IResult> UserUpdateExistCheck(string userName, string phone, string email);
    }
}
