using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationCheck
    {
        public static void Validation(IValidator validator, object objct)
        {
            var context = new ValidationContext<object>(objct);
            ValidationResult validationResult = validator.Validate(context);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}
