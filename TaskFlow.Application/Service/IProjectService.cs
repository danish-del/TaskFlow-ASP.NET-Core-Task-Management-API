using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos.ProjectDto;

namespace TaskFlow.Application.Service
{
    public interface IProjectService
    {
        Task<IEnumerable<ResponseProjectDto>> GetAllAsync();
        Task<ResponseProjectDto?> GetByIdAsync(Guid id);
        Task AddAsync(CreateProjectDto dto);
        Task<bool> UpdateAsync(Guid id,UpdateProjectDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
