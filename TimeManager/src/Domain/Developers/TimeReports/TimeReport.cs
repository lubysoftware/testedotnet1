using System;
using TimeManager.Domain.Projects.ProjectMembers;
using TimeManager.Domain.SeedWork;

namespace TimeManager.Domain.Developers.TimeReports
{
    public class TimeReport : Entity
    {
        public Guid ProjectMemberId { get; }
        public DateTime StartedAt { get; }
        public DateTime EndedAt { get; }

        public TimeSpan CalculatedTimeWorked { get; }
        public int CalculatedWeekNumber { get; }

        public virtual ProjectMember ProjectMember { get; set; }

        public TimeReport(Guid projectMemberId, DateTime startedAt, DateTime endedAt)
        {
            ProjectMemberId = projectMemberId;
            StartedAt = startedAt;
            EndedAt = endedAt;

            this.CalculatedTimeWorked = EndedAt - StartedAt;
            this.CalculatedWeekNumber = DateTime.Now.WeekNumberOfTheYear();
        }
    }
}
