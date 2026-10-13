using TaskFlow.Application.Dtos.ProjectTaskDto;
using TaskFlow.Application.Repositories;
using TaskFlow.Application.Service;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Insfrastructure.Service
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IGenericRepository<ProjectTask> _projectRepo;
        public ProjectTaskService(IGenericRepository<ProjectTask> projectRepo)
        {
            _projectRepo = projectRepo;  
        }
        public async Task<IEnumerable<ResponseProjectTask>> GetAllAsync()
        {
            var result = await _projectRepo.GetAllAsync();
            if(result == null)
                return new List<ResponseProjectTask>();
            return result.Select(x => new ResponseProjectTask
            {
                Title = x.Title,
                Description = x.Description,
                ProjectId = x.ProjectId,
                Status = x.Status,
                TenantId = x.TenantId
            });
        }
        public async Task<ResponseProjectTask?> GetByIdAsync(Guid id)
        {
            var result = await _projectRepo.GetByIdAsync(id);
            if (result == null)
                return null;

            return new ResponseProjectTask
            {
                ProjectId = result.ProjectId,
                Title = result.Title,
                Description = result.Description,
                Status = result.Status,
                TenantId = result.TenantId
            };
        }
        public async Task AddAsync(CreateProjectTask dto)
        {
            var res = new ProjectTask
            {
              
                Title = dto.Title,
                Description = dto.Description,
                ProjectId = dto.ProjectId,
                TenantId = dto.TenantId
            };
            await _projectRepo.AddAsync(res);
            await _projectRepo.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Guid id,UpdateProjectTask dto)
        {
            var res = await _projectRepo.GetByIdAsync(id);
            if (res == null)
                return false;
            res.Title = dto.Title;
            res.Description = dto.Description;
            res.Status = dto.Status;
            res.ProjectId = dto.ProjectId;
            await _projectRepo.UpdateAsync(res);
            await _projectRepo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            await _projectRepo.DeleteAsync(id);
            await _projectRepo.SaveChangesAsync();
            return true;
        }
    }
}
