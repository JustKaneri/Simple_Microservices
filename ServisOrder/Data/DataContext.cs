using Microsoft.EntityFrameworkCore;
using ServisOrder.Model;

namespace ServisOrder.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductCashe> ProductCashes { get; set; }  

        public DbSet<UserCashe> UserCashes { get; set; }
    }
}
