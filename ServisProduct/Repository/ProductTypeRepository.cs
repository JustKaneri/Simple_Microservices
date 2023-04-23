using Microsoft.EntityFrameworkCore;
using ServisProduct.Data;
using ServisProduct.Interface;
using ServisProduct.Model;

namespace ServisProduct.Repository
{
    public class ProductTypeRepository : IProductTypeRepository<TypeProduct>
    {
        private readonly DataContext _context;

        public ProductTypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TypeProduct> Create(TypeProduct entity)
        {
            _context.TypeProducts.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ICollection<TypeProduct>> GetAll()
        {
            return await _context.TypeProducts.ToListAsync();
        }
    }
}
