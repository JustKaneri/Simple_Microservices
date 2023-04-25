using Microsoft.EntityFrameworkCore;
using ServisOrder.Model;

namespace ServisOrder.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Order> Orders { get; set; }
    }
}
