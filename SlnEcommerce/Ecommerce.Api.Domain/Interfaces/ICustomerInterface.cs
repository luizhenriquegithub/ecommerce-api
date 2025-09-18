
using Ecommerce.Api.Domain.Models;
using System.Collections.Generic;

namespace Ecommerce.Api.Domain.Interfaces
{
    public interface ICustomerInterface
    {
        Task<ResponseModel<List<CustomerModel>>> GetAll();
        Task<ResponseModel<CustomerModel>> GetById(int id);
        Task<ResponseModel<CustomerModel>> GetByName(string name);
        Task<ResponseModel<List<CustomerModel>>> PostCustomer(CustomerDto customerDto);

    }

    public class CustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
    }
}
