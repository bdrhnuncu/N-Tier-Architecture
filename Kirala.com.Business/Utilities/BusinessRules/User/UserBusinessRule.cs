using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.Utilities.BusinessRules.User.Abstract;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.DataAccess.Abstract;
using U = Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.BusinessRules.User
{
    public class UserBusinessRule : IUserBusinessRule
    {
        IUserRepository _userRepository;
        public UserBusinessRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<U.User> FindUser(string name, string password)
        {
            var user = await _userRepository.Get(x => x.Name == name && x.Password == password);
            if (user != null)
                return user;
            return null;
        }

        public async Task<IResult> UserUpdateExistCheck(string userName, string phone, string email)
        {
            var user = await _userRepository.Get(x => x.Name.ToLower() == userName.ToLower() && x.Phone == phone && x.Email == email);
            if (user == null)
            {
                var UserName = await _userRepository.Get(x => x.Name.ToLower() == userName.ToLower());
                if (UserName == null)
                {
                    var UserPhone = await _userRepository.Get(x => x.Phone == phone);
                    if (UserPhone == null)
                    {
                        var Email = await _userRepository.Get(x => x.Email == email);
                        if (Email == null)
                        {
                            return new SuccessResult(ConstantMessage.Transactionsuccesfully);
                        }
                        return new ErrorResult(ConstantMessage.EmailUsed);
                    }
                    return new ErrorResult(ConstantMessage.PhoneUsed);
                }
                return new ErrorResult(ConstantMessage.UserNameUsed);
            }
            return new ErrorResult(ConstantMessage.UserUpdateNoChange);

            //var userr = await _userRepository.Get(x => x.Name == userName || x.Phone == phone || x.Email == email);
            //if (userr == null)
            //{
            //    return new SuccessResult();
            //}
            //return new ErrorResult();
        }

        public async Task<IResult> UserExistCheck(string userName, string phone, string email)
        {
            var user = await _userRepository.Get(x => x.Name.ToLower() == userName.ToLower() && x.Phone == phone && x.Email == email);
            if (user != null)
            {
                return new SuccessResult(ConstantMessage.UserExist);
            }
            return new ErrorResult(ConstantMessage.UserNotExist);
        }

        public async Task<IResult> UserRegisterCheck(string userName, string phone, string email)
        {
            var UserName = await _userRepository.Get(x => x.Name.ToLower() == userName.ToLower());
            if (UserName == null)
            {
                var UserPhone = await _userRepository.Get(x => x.Phone == phone);
                if (UserPhone == null)
                {
                    var Email = await _userRepository.Get(x => x.Email == email);
                    if (Email == null)
                    {
                        return new SuccessResult(ConstantMessage.Transactionsuccesfully);
                    }
                    return new ErrorResult(ConstantMessage.EmailUsed);
                }
                return new ErrorResult(ConstantMessage.PhoneUsed);
            }
            return new ErrorResult(ConstantMessage.UserNameUsed);
        }

        public async Task<IResult> UserLoginCheck(string userName, string password)
        {
            var UserName = await _userRepository.Get(x => x.Name.ToLower() == userName.ToLower());
            if (UserName != null)
            {
                if (UserName.Password == password)
                {
                    return new SuccessResult(ConstantMessage.LoginSuccesfully);
                }
                return new ErrorResult(ConstantMessage.UserPasswordWrong);
            }
            return new ErrorResult(ConstantMessage.UserNameNotExist);
        }
    }
}
