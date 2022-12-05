using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.Utilities.BusinessRules.Address.Abstract;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.DataAccess.Abstract;
using A=Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kirala.com.Entities.Dto_s.Address;
using AutoMapper;
using Kirala.com.Entities.Entities;

namespace Kirala.com.Business.Utilities.BusinessRules.Address
{
    public class AddressBusinessRule : IAddressBusinessRule
    {
        IAddressRepository _addressRepository;
        IMapper _mapper;
        public AddressBusinessRule(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddressExistCheckById(int id)
        {
            var exist = await _addressRepository.Get(x => x.Id == id);
            if (exist != null)
                return new SuccessResult();
            return new ErrorResult(ConstantMessage.AddressNotExist);
        }

        public async Task<IResult> AddressExistCheck(A.Address address)
        {
            var exist = await _addressRepository.GetAll(x => x.Equals(address));
            if (exist.Any())
            {
                return new SuccessResult(); 
            }
            return new ErrorResult();
        }
    }
}
