using Microsoft.AspNetCore.Mvc;
using ServisUser.Interface;
using ServisUser.Model;

namespace ServisUser.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class UserController : Controller
    {
        private readonly IUserRepository<User> _repository;
        private readonly IRabbitMQRepository _mQRepository;

        public UserController(IUserRepository<User> repository, IRabbitMQRepository mQRepository)
        {
            _repository = repository;
            _mQRepository = mQRepository;
        }

        [HttpGet("users")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> GetUser()
        {
            var users = await _repository.GetUsers();

            if (users.Count == 0)
                return NotFound();

            return Ok(users);
        }

        [HttpPost("user")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public async Task<IActionResult> CreateUser(User user)
        {
            var users = await _repository.CreateUser(user);

            _mQRepository.SendMessage(users.Id);

            return Ok(users);
        }
    }
}
