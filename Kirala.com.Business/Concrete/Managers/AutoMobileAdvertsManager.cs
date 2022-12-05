using AutoMapper;
using Kirala.com.Business.Abstract;
using Kirala.com.Business.Aspects.Autofac.Validation;
using Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts.Abstract;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Business.Utilities.ValidationRules.AutoMobileAdverts;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Dto_s.AutoMobileAdverts;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Concrete.Managers
{
    public class AutoMobileAdvertsManager : IAutoMobileAdvertsManager
    {
        IAutoMobileAdvertsRepository _advertRepository;
        IMapper _mapper;
        IAutoMobileAdvertsBusinessRule _autoMobileBusinessRule;
        IAddressRepository _addressManager;
        public AutoMobileAdvertsManager(IAutoMobileAdvertsRepository advertRepository, IMapper mapper, 
            IAutoMobileAdvertsBusinessRule autoMobileBusinessRule, IAddressRepository addressManager)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;   
            _autoMobileBusinessRule = autoMobileBusinessRule;
            _addressManager = addressManager;
        }
        
        [ValidationAspect(typeof(AutoMobileAdvertsCreateDtoValidator))]
        public async Task<IResult> Create(AutoMobileAdvertsCreateDto autoMobile)
        {
            var mapAddress = _mapper.Map<Address>(autoMobile);
            var map = _mapper.Map<AutoMobile>(autoMobile);
            var businessRules = await _autoMobileBusinessRule.SameAutoMobileCheck(map);
            if (businessRules.IsSuccess)
            {
                await _addressManager.Create(mapAddress);
                map.AddressId = mapAddress.Id;
                await _advertRepository.Create(map);
                return businessRules;
            }
            return businessRules;
        }

        public async Task<IResult> Delete(AutoMobileAdvertsDto autoMobile)
        {
            var businessRule = await _autoMobileBusinessRule.AutoMobileExistCheck(autoMobile.Id);
            if (businessRule.IsSuccess)
            {
                var map = _mapper.Map<AutoMobile>(autoMobile);
                await _advertRepository.Delete(map);
                return businessRule;
            }
            return businessRule;
        }

        public async Task<IResult> DeleteById(int id)
        {
            var businessRules = await _autoMobileBusinessRule.AutoMobileExistCheck(id);
            if (businessRules.IsSuccess)
            {
                await _advertRepository.DeleteByFilter(x => x.Id == id);
                return businessRules;
            }
            return businessRules;
        }

        public async Task<IDataResult<List<AutoMobileAdvertsDto>>> GetAll()
        {
            var autoMobiles = await _advertRepository.GetAll();
            if (autoMobiles!=null)
            {
                var map = _mapper.Map<List<AutoMobileAdvertsDto>>(autoMobiles);
                return new SuccessDataResult<List<AutoMobileAdvertsDto>>(map);
            }
            return null;
        }

        public async Task<IDataResult<AutoMobileAdvertsDto>> GetById(int id)
        {
            var businessRules = await _autoMobileBusinessRule.AutoMobileExistCheck(id);
            if (businessRules.IsSuccess)
            {
                var autoMobile = await _advertRepository.Get(x => x.Id == id);
                var map = _mapper.Map<AutoMobileAdvertsDto>(autoMobile);
                return new SuccessDataResult<AutoMobileAdvertsDto>(map);
            }
            return null;
        }

        [ValidationAspect(typeof(AutoMobileAdvertsUpdateDtoValidator))]
        public async Task<IResult> Update(AutoMobileAdvertsUpdateDto autoMobile)
        {
            var map = _mapper.Map<AutoMobile>(autoMobile);
            var businessRules = await _autoMobileBusinessRule.SameAutoMobileCheck(map);
            if (businessRules.IsSuccess)
            {
                await _advertRepository.Update(map);
                return businessRules;
            }
            return businessRules;
        }

    }
}
