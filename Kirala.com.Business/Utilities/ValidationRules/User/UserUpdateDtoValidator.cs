using FluentValidation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Entities.Dto_s.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kirala.com.Business.Utilities.ValidationRules.User
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage(ConstantMessage.UserNameNotNull)
                .MaximumLength(20).WithMessage(ConstantMessage.UserNameMaxChar)
                .MinimumLength(4).WithMessage(ConstantMessage.NameMinChar);

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage(ConstantMessage.UserPasswordNotNull)
                .MaximumLength(20).WithMessage(ConstantMessage.UserPasswordMaxChar)
                .MinimumLength(7).WithMessage(ConstantMessage.PasswordMinChar);

            RuleFor(x => x.Phone).NotNull().NotEmpty().WithMessage(ConstantMessage.UserPhoneNotNull)
                .MinimumLength(12).WithMessage(ConstantMessage.UserPhoneMinChar)
                .MaximumLength(14).WithMessage(ConstantMessage.UserPhoneMaxChar)
                .Matches(new Regex("^[\\+][(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")).WithMessage(ConstantMessage.UserPhoneFormat);

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(ConstantMessage.UserEmailNotNull)
                .EmailAddress().WithMessage(ConstantMessage.EmailFormat);
        }
    }
}
