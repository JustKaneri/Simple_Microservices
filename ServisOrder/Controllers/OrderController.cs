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
        private readonly ICasheRepository<UserCashe> _userRepository;
        private readonly ICasheRepository<ProductCashe> _productRepository;

        public OrderController(IOrderRepository<Order> repository,ICasheRepository<UserCashe> userRepository, ICasheRepository<ProductCashe> productRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        [HttpGet("user/{id}/orders")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Order>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetOrderForUser(int id)
        {
            if (await _userRepository.IsExist(id) == false)
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
        public async Task<IActionResult> CreateOrder(int id,int idProduct)
        {

            bool isExistUser = await _userRepository.IsExist(id);
            bool isExistProduct = await _productRepository.IsExist(idProduct);

            if (!isExistUser)
            {
                return BadRequest("Пользователь не найден");
            }

            if (!isExistProduct)
            {
                return BadRequest("Продукт не найден");
            }

            Order enity = new Order();
            enity.ProductId = idProduct;
            enity.UserId = id;
            enity.CreateDate = DateTime.UtcNow;

            var result = await _repository.CreateOrder(enity);

            if (result == null)
                return BadRequest("Не удалось создать заказ");

            return Ok(result);
        }
    }
}
