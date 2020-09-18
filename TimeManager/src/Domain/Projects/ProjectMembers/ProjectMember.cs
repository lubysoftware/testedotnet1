using System;
using TimeManager.Domain.Developers;
using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Projects.ProjectMembers
{
    public class ProjectMember : Entity
    {
        public Guid DeveloperId { get; }
        public Guid ProjectId { get; }
        public DateTime StartedAt { get; }

        public virtual Project Project { get; set; }
        public virtual Developer Developer { get; set; }

        public ProjectMember(Guid developerId, Guid projectId)
        {
            DeveloperId = developerId;
            ProjectId = projectId;
            this.StartedAt = DateTime.Now;
        }
    }
}
