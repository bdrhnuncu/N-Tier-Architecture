using Kirala.com.Business.Utilities.JWT;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Dto_s.User;
using Kirala.com.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Abstract
{
    public interface IUserManager
    {
        Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto);
        Task<IResult> Create(UserRegisterDto user);
        Task<IResult> Update(UserUpdateDto user);
        Task<IResult> DeleteById(int id);
        Task<IResult> Delete(UserDto user);
        Task<IDataResult<List<UserDto>>> GetAll();
        Task<IDataResult<UserDto>> GetById(int id);
    }
}
