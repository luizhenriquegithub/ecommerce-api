
using System.Text.Json.Serialization;

namespace Ecommerce.Api.Domain.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        [JsonIgnore]
        public List<OrderItemModel> Items { get; set; } = new();
        
        public string Status { get; set; } = "Pendente";
        public CustomerModel CustomerModel { get; set; }
    }


    public class OrderItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
