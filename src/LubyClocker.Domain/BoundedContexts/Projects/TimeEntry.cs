using System;
using LubyClocker.Domain.Abstractions;

namespace LubyClocker.Domain.BoundedContexts.Projects
{
    public class TimeEntry : Entity
    {
        public Guid ProjectMemberId { get; set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeSpan WorkedTime { get; private set; }

        public ProjectMember ProjectMember { get; set; }

        public TimeEntry(DateTime start, DateTime end, Guid projectMemberId)
        {
            Start = start;
            End = end;
            WorkedTime = End - Start;
            ProjectMemberId = projectMemberId;
        }
    }
}