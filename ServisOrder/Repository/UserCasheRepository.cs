using ServisOrder.Data;
using ServisOrder.Interface;
using ServisOrder.Model;

namespace ServisOrder.Repository
{
    public class UserCasheRepository : ICasheRepository<UserCashe>
    {
        private readonly DataContext _context;

        public UserCasheRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserCashe> CreateEnity(int id)
        {
            UserCashe user = new UserCashe();
            user.IdUser = id;

            _context.UserCashes.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> IsExist(int id)
        {
            return _context.UserCashes.FindAsync(id) != null;
        }
    }
}
