using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos.ProjectDto;
using TaskFlow.Application.Repositories;
using TaskFlow.Application.Service;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Insfrastructure.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _repo;
        public ProjectService(IGenericRepository<Project> Repo)
        {
            _repo = Repo;
        }
        public async Task<IEnumerable<ResponseProjectDto>> GetAllAsync()
        {
            var proj = await _repo.GetAllAsync();
            if (proj == null)
                return new List<ResponseProjectDto>();
            return proj.Select(x => new ResponseProjectDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                TenantId = x.TenantId,
                UpdatedAt = x.UpdatedAt,    
                CreatedAt = x.CreatedAt
            });
        }
        public async Task<ResponseProjectDto?> GetByIdAsync(Guid id)
        {
            var proj = await _repo.GetByIdAsync(id);
            if (proj == null)
                return null;

            return new ResponseProjectDto
            {
                Id = proj.Id,
                Name = proj.Name,
                Description = proj.Description,
                TenantId = proj.TenantId,
                CreatedAt = proj.CreatedAt,
                UpdatedAt = proj.UpdatedAt
            };
        }
        public async Task AddAsync(CreateProjectDto dto)
        {
            var res = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                TenantId = dto.TenantId
            };
            await _repo.AddAsync(res);
            await _repo.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Guid id,UpdateProjectDto dto)
        {
            var proj = await _repo.GetByIdAsync(id);
            if (proj == null)
                throw new Exception("Not Found!");
            proj.Name = dto.Name;
            proj.Description = dto.Description;
            await _repo.UpdateAsync(proj);
            await _repo.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
