using Microsoft.AspNetCore.Mvc;
using Lab10_Kapitanov_var8.Application.Services;
using Lab10_Kapitanov_var8.Domain.Entities;

namespace Lab10_Kapitanov_var8.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _svc;
        public MedicinesController(IMedicineService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _svc.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var m = await _svc.GetByIdAsync(id);
            return m is null ? NotFound() : Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medicine m)
        {
            await _svc.AddAsync(m);
            return CreatedAtAction(nameof(Get), new { id = m.Id }, m);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Medicine m)
        {
            if (id != m.Id) return BadRequest();
            await _svc.UpdateAsync(m);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }
    }
}