using Ecommerce.Api.Domain.Interfaces;
using Ecommerce.Api.Domain.Models;
using Ecommerce.Api.validator.Error;
using Ecommerce.Api.validator.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerInterface;    
        private readonly IValidator<CustomerDto> _validator;

        public CustomerController(ICustomerInterface customerInterface, IValidator<CustomerDto> validator)
        {
            _customerInterface = customerInterface;
            _validator = validator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ResponseModel<CustomerModel>>> AddCustomer([FromBody] CustomerDto customerDto)
        {
            var validationResult = _validator.Validate(customerDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToCustomerValidatorFailure());
            }

            var customer = await _customerInterface.PostCustomer(customerDto);
            return Ok(customerDto);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseModel<CustomerModel>>> GetAll()
        {
            var customers = await _customerInterface.GetAll();
            return Ok(customers);
        }

        [Authorize]
        [HttpGet("id/{id}")]
        public async Task<ActionResult<ResponseModel<CustomerModel>>> GetById(int id)
        {
            var customers = await _customerInterface.GetById(id);
            return Ok(customers);
        }

        [Authorize]
        [HttpGet("name/{name}")]
        public async Task<ActionResult<ResponseModel<CustomerModel>>> GetByName(string name)
        {
            var customers = await _customerInterface.GetByName(name);
            return Ok(customers);
        }

    }
}
