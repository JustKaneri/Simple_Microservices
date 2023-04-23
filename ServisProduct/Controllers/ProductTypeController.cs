using Microsoft.AspNetCore.Mvc;
using ServisProduct.Interface;
using ServisProduct.Model;

namespace ServisProduct.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class ProductTypeController:Controller
    {
        private readonly IProductTypeRepository<TypeProduct> _repository;

        public ProductTypeController(IProductTypeRepository<TypeProduct> repository)
        {
            _repository = repository;
        }

        [HttpGet("product-type")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAll();

            if (products.Count == 0)
                return NotFound();

            return Ok(products);
        }
    }
}
