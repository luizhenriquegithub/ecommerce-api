
using Ecommerce.Api.Domain.Interfaces;
using Ecommerce.Api.Domain.Models;
using FluentValidation;

namespace Ecommerce.Api.validator.Models
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Document).IsValidCPF().WithMessage("Document é um CPF invalido.");
        }
    }
}
