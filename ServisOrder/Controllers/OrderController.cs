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

        public OrderController(IOrderRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpGet("user/{id}/orders")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Order>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetOrderForUser(int id)
        {
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
            enity.UserId = id;

            var result = await _repository.CreateOrder(enity);

            if (result == null)
                return BadRequest("Не удалось создать заказ");

            return Ok(result);
        }
    }
}
