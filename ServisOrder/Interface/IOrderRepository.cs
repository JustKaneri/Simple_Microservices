namespace ServisOrder.Interface
{
    public interface IOrderRepository<T>
    {
        public Task<ICollection<T>> GetOrderForUser(int id);

        public Task<T> CreateOrder(T enity);
    }
}
