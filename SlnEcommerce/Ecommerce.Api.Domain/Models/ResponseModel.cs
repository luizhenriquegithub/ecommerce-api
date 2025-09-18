
namespace Ecommerce.Api.Domain.Models
{
    public class ResponseModel<T>
    {
        public T? Result { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
