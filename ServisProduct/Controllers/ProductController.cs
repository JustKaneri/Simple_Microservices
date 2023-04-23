using Microsoft.AspNetCore.Mvc;
using ServisProduct.Interface;
using ServisProduct.Model;

namespace ServisProduct.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class ProductController : Controller
    {
        private readonly IProductRepository<Product> _repository;

        public ProductController(IProductRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet("products")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();

            if (result.Count == 0)
                return NotFound("Продуктов нет");

            return Ok(result);
        }

        [HttpGet("product")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<IActionResult> FindProduct(int id)
        {
            var result = await _repository.GetCurrent(id);

            if (result == null)
                return BadRequest("Не удалось найти продукт");

            return Ok(result);
        }

        [HttpPost("product")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<IActionResult> CreateProduct(Product enity)
        {
            //Тут должен был быть AutoMapper, но для упрощения он не был добавлен.
            var result = await _repository.Create(enity);

            if (result == null)
                return BadRequest("Не удалось создать продукт");

            return Ok(result);
        }
    }
}
