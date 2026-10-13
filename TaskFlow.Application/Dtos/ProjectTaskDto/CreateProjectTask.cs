using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Enum;

namespace TaskFlow.Application.Dtos.ProjectTaskDto
{
    public class CreateProjectTask
    {
        public Guid TenantId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid ProjectId { get; set; }
    }
}
