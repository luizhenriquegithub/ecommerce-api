using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.validator.Error
{
    public static class ValidationFailureExtension
    {
        public static IList<CustomerValidatorFailure> ToCustomerValidatorFailure(this IList<ValidationFailure> failures)
        {
            return failures.Select(f => new CustomerValidatorFailure(f.PropertyName, f.ErrorMessage)).ToList();
        }
    }
}
