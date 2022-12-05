using AutoMapper;
using Kirala.com.Business.Abstract;
using Kirala.com.Business.Aspects.Autofac.Validation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.Utilities.BusinessRules.Address.Abstract;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Business.Utilities.ValidationRules.Address;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Dto_s.Address;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Concrete.Managers
{
    public class AddressManager : IAddressManager
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;
        IAddressBusinessRule _addressBusinessRule;
        public AddressManager(IAddressRepository addressRepository, IMapper mapper, IAddressBusinessRule addressBusinessRule)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _addressBusinessRule = addressBusinessRule;
        }

        [ValidationAspect(typeof(AddressCreateDtoValidator))]
        public async Task<IResult> Create(AddressCreateDto address)
        {
            var map = _mapper.Map<Address>(address);
            await _addressRepository.Create(map);
            return new SuccessResult(ConstantMessage.Transactionsuccesfully);
        }

        public async Task<IResult> Delete(AddressDto addressDto)
        {
            var map = _mapper.Map<Address>(addressDto);
            var exist = await _addressBusinessRule.AddressExistCheck(map);
            if (exist.IsSuccess)
            {
                await _addressRepository.Delete(map);
                return new SuccessResult(ConstantMessage.Transactionsuccesfully);
            }
            return new ErrorResult(ConstantMessage.AddressNotExist);
        }

        public async Task<IResult> DeleteById(int id)
        {
            var exist = await _addressBusinessRule.AddressExistCheckById(id);
            if (exist.IsSuccess)
            {
                await _addressRepository.DeleteByFilter(x => x.Id == id);
                return new SuccessResult(ConstantMessage.Transactionsuccesfully);
            }
            return exist;
        }

        public async Task<IDataResult<List<AddressDto>>> GetAll()
        {
            var query = await _addressRepository.GetAll();
            if (query != null)
            {
                var map = _mapper.Map<List<AddressDto>>(query);
                return new SuccessDataResult<List<AddressDto>>(map);

            }
            return null;
        }

        public async Task<IDataResult<AddressDto>> GetById(int id)
        {
            var exist = await _addressBusinessRule.AddressExistCheckById(id);
            if (exist.IsSuccess)
            {
                var get = await _addressRepository.Get(x => x.Id == id);
                var map = _mapper.Map<AddressDto>(get);
                return new SuccessDataResult<AddressDto>(map);
            }
            return null;
        }

        [ValidationAspect(typeof(AddressUpdateDtoValidator))]
        public async Task<IResult> Update(AddressUpdateDto address)
        {
            var map = _mapper.Map<Address>(address);
            await _addressRepository.Update(map);
            return new SuccessResult(ConstantMessage.Transactionsuccesfully);
        }
    }
}
