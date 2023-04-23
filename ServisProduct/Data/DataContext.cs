using Microsoft.EntityFrameworkCore;
using ServisProduct.Model;

namespace ServisProduct.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<TypeProduct> TypeProducts { get; set; }
    }
}
