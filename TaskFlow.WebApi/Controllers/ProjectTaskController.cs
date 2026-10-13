using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos.ProjectTaskDto;
using TaskFlow.Application.Service;

namespace TaskFlow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
        private readonly IProjectTaskService _projectTaskService;
        public ProjectTaskController(IProjectTaskService ProjectTaskService)
        {
            _projectTaskService = ProjectTaskService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var res =  await _projectTaskService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var res = await _projectTaskService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateProjectTask dto)
        {
            await _projectTaskService.AddAsync(dto);
            return Ok("Added Successfully!");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateProjectTask dto)
        {
            await _projectTaskService.UpdateAsync(id, dto);
            return Ok("Updated Successfully!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _projectTaskService.DeleteAsync(id);
            return Ok("Deleted Successfully!");
        }
    }
}
