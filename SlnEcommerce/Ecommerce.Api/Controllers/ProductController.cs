using Ecommerce.Api.Application.DTOs;
using Ecommerce.Api.Domain.Interfaces;
using Ecommerce.Api.Domain.Models;
using Ecommerce.Api.validator.Error;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInteface _productInteface;
        private readonly IValidator _validator;

        public ProductController(IProductInteface productInteface, IValidator validator)
        {
            _productInteface = productInteface;
            _validator = validator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ProductModel>>> Save([FromBody] ProductModel productDto)
        {
            //var validationResult = _validator.Validate(productDto);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors.ToCustomerValidatorFailure());
            //}

            var product = await _productInteface.Save(productDto);
            return Ok(product);
        }

    }
}
