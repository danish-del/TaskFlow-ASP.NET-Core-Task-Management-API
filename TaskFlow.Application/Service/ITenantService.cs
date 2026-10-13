using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos.TenantDto;

namespace TaskFlow.Application.Service
{
    public interface ITenantService
    {
        Task<IEnumerable<ResponseTenantDto>> GetAllAsync();
        Task<ResponseTenantDto?> GetByIdAsync(Guid id);
        Task AddAsync(CreateTenantDto dto);
        Task<bool> UpdateAsync(Guid id, UpdateTenantDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
