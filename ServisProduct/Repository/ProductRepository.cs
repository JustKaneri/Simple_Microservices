using Microsoft.EntityFrameworkCore;
using ServisProduct.Data;
using ServisProduct.Interface;
using ServisProduct.Model;

namespace ServisProduct.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product entity)
        {
            entity.TypeId = _context.TypeProducts.First().Id;

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetCurrent(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
