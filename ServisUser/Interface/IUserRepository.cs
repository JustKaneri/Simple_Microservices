namespace ServisUser.Interface
{
    public interface IUserRepository<T>
    {
        public Task<List<T>> GetUsers();

        public Task<T> UpdateUser(T user);

        public Task<T> CreateUser(T user);

        public Task<T> DeleteUser(T user);
    }
}
