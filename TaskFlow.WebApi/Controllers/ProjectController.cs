using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Common.Interface;
using TaskFlow.Application.Dtos.ProjectDto;
using TaskFlow.Application.Service;

namespace TaskFlow.WebApi.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ICacheService _cache;
        public ProjectController(IProjectService projectService,
            ICacheService Cache)
        {
            _projectService = projectService;
            _cache = Cache;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _projectService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var res = await _projectService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateProjectDto dto)
        {
            await _projectService.AddAsync(dto);
            return Ok("Data Added Successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdateProjectDto dto)
        {
            await _projectService.UpdateAsync(id, dto);
            return Ok("Updated Successfully!");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return Ok("Deleted Successfully!");
        }
    }
}