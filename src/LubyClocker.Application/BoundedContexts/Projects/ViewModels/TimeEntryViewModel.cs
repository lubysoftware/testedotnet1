using System;
using LubyClocker.CrossCuting.Shared.ViewModels;
using LubyClocker.Domain.BoundedContexts.Projects;

namespace LubyClocker.Application.BoundedContexts.Projects.ViewModels
{
    public class TimeEntryViewModel : BaseViewModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan WorkedTime { get; set; }
        
        public ProjectMemberViewModel ProjectMember { get; set; }
        public TimeEntryViewModel(TimeEntry persistedEntity)
        {
            Id = persistedEntity.Id;
            CreatedAt = persistedEntity.CreatedAt;
            Start = persistedEntity.Start;
            End = persistedEntity.End;
            WorkedTime = persistedEntity.WorkedTime;
            ProjectMember = new ProjectMemberViewModel(persistedEntity.ProjectMember);
        }

        public TimeEntryViewModel()
        {
            
        }
        
    }
}