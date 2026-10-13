using TaskFlow.Domain.Common;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enum;

public class ProjectTask : BaseEntity, ITenantEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.Todo;
    public Guid TenantId { get; set; }
    public Guid ProjectId { get; set; }

    public Project Project { get; set; } = null!;
}
