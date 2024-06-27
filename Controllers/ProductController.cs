using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.DTO;
using ProductWebAPI.Repositories;
using ProductWebAPI.ViewModel;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel product)
        {
            var productDTO = new ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            var result = await _productRepository.Add(productDTO);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productRepository.Get();

            return Ok(result);
        }

        [HttpGet("/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productRepository.GetById(id);

            return Ok(result);
        }

        [HttpDelete("/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productRepository.Delete(id);

            return Ok(result);
        }

        [HttpPut("/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductViewModel product)
        {
            var productDTO = new ProductDTO
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            var result = await _productRepository.Update(productDTO);

            return Ok(result);
        }
    }
}
