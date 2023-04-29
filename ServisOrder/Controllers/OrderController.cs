using Microsoft.AspNetCore.Mvc;
using ServisOrder.Interface;
using ServisOrder.Model;

namespace ServisOrder.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository<Order> _repository;
        private readonly ICasheRepository<UserCashe> _casheRepository;

        public OrderController(IOrderRepository<Order> repository,ICasheRepository<UserCashe> casheRepository)
        {
            _repository = repository;
            _casheRepository = casheRepository;
        }

        [HttpGet("user/{id}/orders")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Order>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetOrderForUser(int id)
        {
            if (await _casheRepository.IsExist(id))
            {
                return BadRequest("Пользователь не найден");
            }

            var result = await _repository.GetOrderForUser(id);

            if (result.Count == 0)
                return NotFound("Заказы не найдены");

            return Ok(result);
        }

        [HttpPost("user/{id}/order")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> CreateOrder(int id,Order enity)
        {
            if (await _casheRepository.IsExist(id))
            {
                return BadRequest("Пользователь не найден");
            }

            enity.UserId = id;

            var result = await _repository.CreateOrder(enity);

            if (result == null)
                return BadRequest("Не удалось создать заказ");

            return Ok(result);
        }
    }
}
