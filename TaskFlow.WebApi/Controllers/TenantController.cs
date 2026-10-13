using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos.TenantDto;
using TaskFlow.Application.Service;

namespace TaskFlow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService TenantService)
        {
            _tenantService = TenantService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tenant = await _tenantService.GetAllAsync();
            return Ok(tenant);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var tenant = await _tenantService.GetByIdAsync(id);
            return Ok(tenant);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateTenantDto dto)
        {
             await _tenantService.AddAsync(dto);
            return Ok("Added Successfully!");
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateAsync(Guid id,UpdateTenantDto dto)
        {
            await _tenantService.UpdateAsync(id, dto);
            return Ok("Updated Successfully!");
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _tenantService.DeleteAsync(id);
            return Ok("Deleted Successfully!");
        }
    }
}
