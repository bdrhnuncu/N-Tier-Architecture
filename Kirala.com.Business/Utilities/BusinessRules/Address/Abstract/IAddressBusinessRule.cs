using Kirala.com.Business.Utilities.Results.Abstract;
using A = Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.BusinessRules.Address.Abstract
{
    public interface IAddressBusinessRule
    {
        Task<IResult> AddressExistCheckById(int id);
        Task<IResult> AddressExistCheck(A.Address address);
    }
}
