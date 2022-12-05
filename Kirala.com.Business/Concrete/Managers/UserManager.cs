﻿using AutoMapper;
using Kirala.com.Business.Abstract;
using Kirala.com.Business.Aspects.Autofac.Validation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.Utilities.BusinessRules.User.Abstract;
using Kirala.com.Business.Utilities.JWT;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Business.Utilities.ValidationRules.User;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Dto_s.User;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Concrete.Managers
{
    public class UserManager : IUserManager
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        IUserBusinessRule _userBusinessRule;
        IJwtHelper _jwtHelper;
        public UserManager(IUserRepository userRepository, IMapper mapper, IUserBusinessRule userBusinessRule, IJwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRule = userBusinessRule;
            _jwtHelper = jwtHelper;
        }

        public async Task<IDataResult<AccessToken>> Login(UserLoginDto userLoginDto)
        {
            var loginCheck = await _userBusinessRule.UserLoginCheck(userLoginDto.Name, userLoginDto.Password);
            if (loginCheck.IsSuccess)
            {
                var map = _mapper.Map<User>(userLoginDto);
                var token = _jwtHelper.CreateToken(map);
                return new SuccessDataResult<AccessToken>(token);
            }
            return new ErrorDataResult<AccessToken>(null,loginCheck.Message);
        }

        [ValidationAspect(typeof(UserRegisterDtoValidator))]
        public async Task<IResult> Create(UserRegisterDto user)
        {
            var businessRules = await _userBusinessRule.UserRegisterCheck(user.Name, user.Phone, user.Email);
            if (businessRules.IsSuccess)
            {
                var map = _mapper.Map<User>(user);
                await _userRepository.Create(map);
                return businessRules;
            }
            return businessRules;
        }

        public async Task<IResult> Delete(UserDto user)
        {
            var businessRules = await _userBusinessRule.UserExistCheck(user.Name, user.Phone, user.Email);
            if (businessRules.IsSuccess)
            {
                var map = _mapper.Map<User>(user);
                await _userRepository.Delete(map);
                return businessRules;
            }
            return businessRules;
        }

        public async Task<IResult> DeleteById(int id)
        {
            var user = await _userRepository.Get(x => x.Id == id);
            if (user != null)
            {
                await _userRepository.DeleteByFilter(x => x.Id == id);
                return new SuccessResult(ConstantMessage.Transactionsuccesfully);
            }
            return new ErrorResult(ConstantMessage.UserIdNotExist);
        }

        public async Task<IDataResult<List<UserDto>>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if (users != null)
            {
                var map = _mapper.Map<List<UserDto>>(users);
                return new SuccessDataResult<List<UserDto>>(map);
            }
            return null;
        }

        public async Task<IDataResult<UserDto>> GetById(int id)
        {
            var user = await _userRepository.Get(x => x.Id == id);
            if (user != null)
            {
                var map = _mapper.Map<UserDto>(user);
                return new SuccessDataResult<UserDto>(map);
            }
            return null;
        }

        [ValidationAspect(typeof(UserUpdateDto))]
        public async Task<IResult> Update(UserUpdateDto user)
        {
            var businessRules = await _userBusinessRule.UserUpdateExistCheck(user.Name, user.Phone, user.Email);
            if (businessRules.IsSuccess)
            {
                var map = _mapper.Map<User>(user);
                await _userRepository.Update(map);
                return businessRules;
            }
            return businessRules;
        }

    }
}
