using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Dtos.TenantDto;
using TaskFlow.Application.Repositories;
using TaskFlow.Application.Service;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Insfrastructure.Service
{
    public class TenantService : ITenantService
    {
        private readonly IGenericRepository<Tenant> _generic;
        public TenantService(IGenericRepository<Tenant> Generic)
        {
            _generic = Generic;
        }
        public async Task<IEnumerable<ResponseTenantDto>> GetAllAsync()
        {
            var result = await _generic.GetAllAsync();
            if (result == null)
            {
                return new List<ResponseTenantDto>();
            }
            return result.Select(x => new ResponseTenantDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                isActive = x.isActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });
        }
        public async Task<ResponseTenantDto?> GetByIdAsync(Guid id)
        {
            var result = await _generic.GetByIdAsync(id);
            if (result == null)
                return null;

            return new ResponseTenantDto
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                isActive = result.isActive,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
        public async Task AddAsync(CreateTenantDto dto)
        {
            var result = new Tenant
            {
                Name = dto.Name,
                Description = dto.Description
            };
            await _generic.AddAsync(result);
            await _generic.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Guid id, UpdateTenantDto dto)
        {
            var res = await _generic.GetByIdAsync(id);
            if (res == null)
                throw new Exception("Not found!");
            res.Name = dto.Name;
            res.Description = dto.Description;
            await _generic.UpdateAsync(res);
            await _generic.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            await _generic.DeleteAsync(id);
            return true;
        }
    }
}
