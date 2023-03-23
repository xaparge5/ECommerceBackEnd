
using ECommerce.HTTPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.HTTPAPI.Repository
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
