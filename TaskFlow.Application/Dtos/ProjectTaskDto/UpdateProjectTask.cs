using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Enum;

namespace TaskFlow.Application.Dtos.ProjectTaskDto
{
    public class UpdateProjectTask
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.Todo;
        public Guid ProjectId { get; set; }
    }
}
