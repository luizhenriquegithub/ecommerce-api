using Ecommerce.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; } 
        public DbSet<OrderItemModel> OrderItens { get; set; }
        public DbSet<ProductModel> Products { get; set; }



    }
}
