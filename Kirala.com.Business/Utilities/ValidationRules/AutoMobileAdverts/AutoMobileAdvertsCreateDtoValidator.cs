using FluentValidation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Entities.Dto_s.AutoMobileAdverts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.ValidationRules.AutoMobileAdverts
{
    public class AutoMobileAdvertsCreateDtoValidator : AbstractValidator<AutoMobileAdvertsCreateDto>
    {
        public AutoMobileAdvertsCreateDtoValidator()
        {
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage(ConstantMessage.AdvertDescription);
            RuleFor(x => x.Year).NotNull().NotEmpty().WithMessage(ConstantMessage.YearNotNull)
                .LessThanOrEqualTo(Year());
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage(ConstantMessage.PriceNotNull)
                .Must(RegexPrice).WithMessage(ConstantMessage.PriceFormat);
            RuleFor(x => x.Mile).NotNull().NotEmpty().WithMessage(ConstantMessage.MileNotNull)
                .Matches(new Regex("^[0-9]*$"));
            RuleFor(x => x.CityId).NotEmpty().NotNull().WithMessage(ConstantMessage.CityNull);
            RuleFor(x => x.District).NotEmpty().NotNull().WithMessage(ConstantMessage.DistrictNull);
        }

        private bool RegexPrice(double Price)
        {
            Regex rgx = new Regex("(\\d+(\\.?\\d{1,2})?)");
            return rgx.IsMatch(Price.ToString());
        }

        private string Year()
        {
            var yearNow = DateTime.Now.Year + 1;
            return yearNow.ToString();
        }
    }
}
