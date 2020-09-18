using System;
using System.Collections.Generic;
using LubyClocker.Domain.Abstractions;
using LubyClocker.Domain.BoundedContexts.Developers;

namespace LubyClocker.Domain.BoundedContexts.Projects
{
    public class ProjectMember : Entity
    {
        public DateTime EntryDate { get; set; }
        public Guid DeveloperId { get; set; }
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }
        public Developer Developer { get; set; }
        
        public ICollection<TimeEntry> TimeEntries { get; set; }

        public ProjectMember(DateTime entryDate, Guid developerId, Guid projectId)
        {
            EntryDate = entryDate;
            DeveloperId = developerId;
            ProjectId = projectId;
        }

        public ProjectMember()
        {
            
        }
    }
}