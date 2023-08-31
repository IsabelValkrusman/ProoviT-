using Microsoft.EntityFrameworkCore;
using ProoviTöö.Models;

namespace ProoviTöö.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
