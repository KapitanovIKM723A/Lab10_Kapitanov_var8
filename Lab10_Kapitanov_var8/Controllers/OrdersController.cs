using Microsoft.AspNetCore.Mvc;
using Lab10_Kapitanov_var8.Application.Services;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _svc;
        public OrdersController(IOrderService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _svc.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var o = await _svc.GetByIdAsync(id);
            return o is null ? NotFound() : Ok(o);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order o)
        {
            await _svc.PlaceOrderAsync(o);
            return CreatedAtAction(nameof(Get), new { id = o.Id }, o);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Order o)
        {
            if (id != o.Id) return BadRequest();
            await _svc.UpdateAsync(o);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _svc.CancelAsync(id);
            return NoContent();
        }
    }
}