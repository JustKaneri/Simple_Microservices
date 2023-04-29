namespace ServisOrder.Interface
{
    public interface ICasheRepository<T>
    {
        public Task<T> CreateEnity(int id);

        public Task<Boolean> IsExist(int id);
    }
}
