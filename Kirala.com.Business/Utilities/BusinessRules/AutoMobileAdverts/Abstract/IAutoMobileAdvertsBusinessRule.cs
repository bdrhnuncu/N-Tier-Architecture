using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts.Abstract
{
    public interface IAutoMobileAdvertsBusinessRule
    {
        Task<IResult> SameAutoMobileCheck(AutoMobile advertsDto);
        Task<IResult> AutoMobileExistCheck(int id);
    }
}
