namespace ServisProduct.Interface
{
    public interface IDefaultPepository <T>
    {
        public Task<ICollection<T>> GetAll();
        public Task<T> Create(T entity);
    }
}
