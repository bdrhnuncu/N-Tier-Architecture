using FluentValidation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Entities.Dto_s.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.ValidationRules.Address
{
    public class AddressCreateDtoValidator : AbstractValidator<AddressCreateDto>
    {
        public AddressCreateDtoValidator()
        {
            RuleFor(x => x.CityId).NotEmpty().NotNull().WithMessage(ConstantMessage.CityNull);
            RuleFor(x => x.District).NotEmpty().NotNull().WithMessage(ConstantMessage.DistrictNull);
        }
    }
}
