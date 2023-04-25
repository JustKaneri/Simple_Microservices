using Microsoft.EntityFrameworkCore;
using ServisOrder.Data;
using ServisOrder.Interface;
using ServisOrder.Model;

namespace ServisOrder.Repository
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order enity)
        {
            try
            {
                _context.Orders.Add(enity);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                return null;
            }
            

            return enity;
        }

        public async Task<ICollection<Order>> GetOrderForUser(int id)
        {
            return await _context.Orders.Where(u => u.UserId == id).ToListAsync();
        }
    }
}
