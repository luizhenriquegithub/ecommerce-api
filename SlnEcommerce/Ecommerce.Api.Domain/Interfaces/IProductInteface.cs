using Ecommerce.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Domain.Interfaces
{
    public interface IProductInteface
    {
        Task<ResponseModel<ProductModel>> Save(ProductModel productModel);
        
    }
}


//public interface IProdutoService
//{
//    
//    IEnumerable<Produto> ConsultarProdutos();
//    void AtualizarEstoque(Guid produtoId, int quantidadeVendida);
//}
