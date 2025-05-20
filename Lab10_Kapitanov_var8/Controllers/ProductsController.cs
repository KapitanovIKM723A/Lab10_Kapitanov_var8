using Lab10_Kapitanov_var8.Infrastructure;
using Lab10_Kapitanov_var8.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab10_Kapitanov_var8.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        public ProductsController(AppDbContext ctx) => _ctx = ctx;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _ctx.Products
                                     .Include(p => p.Category)
                                     .ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _ctx.Products
                                    .Include(p => p.Category)
                                    .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var cat = await _ctx.Categories.FindAsync(product.CategoryId);
            if (cat == null)
                return BadRequest($"Category {product.CategoryId} does not exist.");

            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();

            await _ctx.Entry(product).Reference(p => p.Category).LoadAsync();

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}
