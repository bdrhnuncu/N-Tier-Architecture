using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Entities.Dto_s.Address;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Abstract
{
    public interface IAddressManager
    {
        Task<IResult> Create(AddressCreateDto address);
        Task<IResult> Update(AddressUpdateDto address);
        Task<IResult> DeleteById(int id);
        Task<IResult> Delete(AddressDto addressDto);
        Task<IDataResult<List<AddressDto>>> GetAll();
        Task<IDataResult<AddressDto>> GetById(int id);
    }
}
