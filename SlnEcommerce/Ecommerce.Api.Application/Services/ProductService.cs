using Ecommerce.Api.Application.DTOs;
using Ecommerce.Api.Domain.Interfaces;
using Ecommerce.Api.Domain.Models;
using Ecommerce.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Application.Services
{
    public class ProductService : IProductInteface
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProductModel>> Save(ProductModel productModel)
        {
            var resposta = new ResponseModel<ProductModel>();
            try
            {
                var product = new ProductModel
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    Quantity = productModel.Quantity
                };

                _context.Products.Add(productModel);
                await _context.SaveChangesAsync();

                resposta.Result = await _context.Products.FindAsync();
                resposta.Mensagem = "Produto criado com sucesso";
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
