using Ecommerce.Api.Application.DTOs;
using FluentValidation;

namespace Ecommerce.Api.validator.Models
{
    public class ProductValidator :AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }

    }
}
