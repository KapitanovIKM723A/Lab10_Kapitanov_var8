using Microsoft.AspNetCore.Mvc;
using Lab10_Kapitanov_var8.Application.Services;

namespace Lab10_Kapitanov_var8.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugInfoController : ControllerBase
    {
        private readonly DrugInfoService _svc;
        public DrugInfoController(DrugInfoService svc) => _svc = svc;

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var info = await _svc.GetUsageAsync(name);
            if (info == null)
                return NotFound(new { message = "Інформація не знайдена" });

            return Ok(new { drug = name, details = info });
        }
    }
}