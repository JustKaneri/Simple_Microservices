using Microsoft.EntityFrameworkCore;
using ServisOrder.Data;
using ServisOrder.Interface;
using ServisOrder.Model;

namespace ServisOrder.Repository
{
    public class ProductCasheRepository : ICasheRepository<ProductCashe>
    {
        private readonly DataContext _context;

        public ProductCasheRepository(DataContext context)
        {
           _context = context;
        }
        public async Task<ProductCashe> CreateEnity(int id)
        {
            ProductCashe productCashe = new ProductCashe();
            productCashe.IdProduct = id;

            _context.ProductCashes.Add(productCashe);
            await _context.SaveChangesAsync();

            return productCashe;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.ProductCashes.Where(p => p.IdProduct == id).FirstOrDefaultAsync() != null;
        }
    }
}
