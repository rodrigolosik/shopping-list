using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingList.Domain.Models;
using ShoppingList.Service.Shoppings;
using System.Threading.Tasks;

namespace ShoppingList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingsController : ControllerBase
    {
        private readonly ILogger<ShoppingsController> _logger;
        private readonly IShoppingService _service;

        public ShoppingsController(ILogger<ShoppingsController> logger, IShoppingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.Get());

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var shopping = await _service.Get(id);

            if (shopping == null)
                return NotFound();

            return Ok(shopping);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shopping shopping)
        {
            await _service.Create(shopping);
            return Created($"Shopping", shopping);
        }
    }
}
