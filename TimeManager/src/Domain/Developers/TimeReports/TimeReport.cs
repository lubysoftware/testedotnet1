using System;
using TimeManager.Domain.Projects;
using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Developers.TimeReports
{
    public class TimeReport : Entity
    {
        public Guid DeveloperId { get; }
        public Guid ProjectId { get; }
        public DateTime StartedAt { get; }
        public DateTime EndedAt { get; }

        public TimeSpan CalculatedTimeWorked { get; }

        public virtual Developer Developer { get; set; }
        public virtual Project Project { get; set; }

        public TimeReport(Guid developerId, Guid projectId, DateTime startedAt, DateTime endedAt)
        {
            DeveloperId = developerId;
            ProjectId = projectId;
            StartedAt = startedAt;
            EndedAt = endedAt;

            this.CalculatedTimeWorked = EndedAt - StartedAt;
        }
    }
}
