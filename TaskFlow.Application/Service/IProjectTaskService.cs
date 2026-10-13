using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos.ProjectDto;
using TaskFlow.Application.Dtos.ProjectTaskDto;

namespace TaskFlow.Application.Service
{
    public interface IProjectTaskService
    {
        Task<IEnumerable<ResponseProjectTask>> GetAllAsync();
        Task<ResponseProjectTask?> GetByIdAsync(Guid id);
        Task AddAsync(CreateProjectTask dto);
        Task<bool> UpdateAsync(Guid id,UpdateProjectTask dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
