using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingList.Domain.Models;
using ShoppingList.Service.Products;
using System.Threading.Tasks;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _service;

        public ProductsController(ILogger<ProductsController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(_service.Get());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = _service.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            _service.Create(product);

            return Created($"Products", product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = _service.Get(id);

            if (product == null)
                return NotFound();

            _service.Remove(product.Id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Product productIn)
        {
            var product = _service.Get(id);

            if (product == null)
                return NotFound();

            _service.Update(id, productIn);

            return NoContent();
        }
    }
}
