namespace ServisProduct.Interface
{
    public interface IProductRepository<T> : IDefaultPepository<T>
    {
        public Task<T> GetCurrent(int id);
    }
}
