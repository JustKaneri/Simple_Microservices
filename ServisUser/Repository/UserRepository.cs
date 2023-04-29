using Microsoft.EntityFrameworkCore;
using ServisUser.Data;
using ServisUser.Interface;
using ServisUser.Model;

namespace ServisUser.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        public readonly DataContext _context;
        private readonly ILogger _logger;

        public UserRepository(DataContext context, ILogger<Program> logger)
        {
            _context = context; 
            _logger = logger;
        }

        public async Task<User> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }

            return user;
        }

        public async Task<User> DeleteUser(User user)
        {
            var isExist = _context.Users.Find(user.Id) != null;

            if (!isExist)
                return null;

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var user = await _context.Users.ToListAsync();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var isExist = _context.Users.Find(user.Id) != null;

            if (!isExist)
                return null;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return user;
        }
    }
}
