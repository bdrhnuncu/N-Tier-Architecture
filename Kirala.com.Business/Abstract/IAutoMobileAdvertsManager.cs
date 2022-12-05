using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.Entities.Dto_s.AutoMobileAdverts;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Abstract
{
    public interface IAutoMobileAdvertsManager
    {
        Task<IResult> Create(AutoMobileAdvertsCreateDto autoMobile);
        Task<IResult> Update(AutoMobileAdvertsUpdateDto autoMobile);
        Task<IResult> DeleteById(int id);
        Task<IResult> Delete(AutoMobileAdvertsDto autoMobile);
        Task<IDataResult<List<AutoMobileAdvertsDto>>> GetAll();
        Task<IDataResult<AutoMobileAdvertsDto>> GetById(int id);
    }
}
