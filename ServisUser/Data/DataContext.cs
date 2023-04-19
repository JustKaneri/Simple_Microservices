using Microsoft.EntityFrameworkCore;
using ServisUser.Model;

namespace ServisUser.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
