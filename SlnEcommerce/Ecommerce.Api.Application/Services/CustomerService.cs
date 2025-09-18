using Ecommerce.Api.Domain.Interfaces;
using Ecommerce.Api.Domain.Models;
using Ecommerce.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Ecommerce.Api.Application.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;    
        }

        public async Task<ResponseModel<List<CustomerModel>>> GetAll()
        {
            var resposta = new ResponseModel<List<CustomerModel>>();
            try
            {
                var costumers = await _context.Customers.ToListAsync();
                resposta.Result = costumers;
                resposta.Mensagem = "Todos os clientes foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            } 
        }

        public async Task<ResponseModel<CustomerModel>> GetById(int id)
        {
            var resposta = new ResponseModel<CustomerModel>();
            try
            {
                var customers = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (customers == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                
                resposta.Result = customers;
                resposta.Mensagem = "Cliente localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CustomerModel>> GetByName(string name)
        {
            var resposta = new ResponseModel<CustomerModel>();
            try
            {
                var customers = await _context.Customers.Where(x => x.Name == name).FirstOrDefaultAsync(); 
                if (customers == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Result = customers;
                resposta.Mensagem = "Clientes localizados";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<CustomerModel>>> PostCustomer(CustomerDto customerDto)
        {
            var resposta = new ResponseModel<List<CustomerModel>>();
            try
            {
                var customer = new CustomerModel
                {
                    Name = customerDto.Name,
                    Email = customerDto.Email,
                    Document = customerDto.Document
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                resposta.Result = await _context.Customers.ToListAsync();
                resposta.Mensagem = "Customer criado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
