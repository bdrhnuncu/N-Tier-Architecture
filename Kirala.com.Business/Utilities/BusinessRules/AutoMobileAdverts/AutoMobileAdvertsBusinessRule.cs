using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts.Abstract;
using Kirala.com.Business.Utilities.Results;
using Kirala.com.Business.Utilities.Results.Abstract;
using Kirala.com.DataAccess.Abstract;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.BusinessRules.AutoMobileAdverts
{
    public class AutoMobileAdvertsBusinessRule : IAutoMobileAdvertsBusinessRule
    {
        IAutoMobileAdvertsRepository _autoMobileAdverts;
        public AutoMobileAdvertsBusinessRule(IAutoMobileAdvertsRepository autoMobileAdverts)
        {
            _autoMobileAdverts = autoMobileAdverts;
        }

        public async Task<IResult> SameAutoMobileCheck(AutoMobile advertsDto)
        {
            var autoMobiles = await _autoMobileAdverts.GetAll(x=>x.Equals(advertsDto));
            if (!autoMobiles.Any())
            {
                return new SuccessResult(ConstantMessage.Transactionsuccesfully);
            }
            return new ErrorResult(ConstantMessage.SameAdvertNotAdd);
        }

        public async Task<IResult> AutoMobileExistCheck(int id)
        {
            var autoMobile = await _autoMobileAdverts.Get(x => x.Id == id);
            if (autoMobile!=null)
            {
                return new SuccessResult(ConstantMessage.Transactionsuccesfully);
            }
            return new ErrorResult(ConstantMessage.AdvertIdNotExist);
        }
    }
}