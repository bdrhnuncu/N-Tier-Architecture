using Castle.DynamicProxy;
using FluentValidation;
using Kirala.com.Business.Constants.Messages;
using Kirala.com.Business.CrossCuttingConcerns.Validation.FluentValidation;
using Kirala.com.Business.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kirala.com.Business.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        Type _validator;
        public ValidationAspect(Type validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(validator))
            {
                throw new System.Exception(ConstantMessage.WrongValidationType);
            }

            _validator = validator;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validator);
            var entityType = _validator.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationCheck.Validation(validator, invocation.Arguments[0]);
            }
        }
    }
}
