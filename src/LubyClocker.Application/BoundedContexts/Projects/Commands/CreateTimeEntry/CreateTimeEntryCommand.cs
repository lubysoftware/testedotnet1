using System;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.CrossCuting.Shared.Validators;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.CreateTimeEntry
{
    public class CreateTimeEntryCommand : Command<TimeEntryViewModel>
    {
        public Guid ProjectId { get; internal set; }
        public Guid ProjectMemberId { get; internal set; }
        [RequiredDateTime]
        public DateTime Start { get; set; }
        [RequiredDateTime]
        public DateTime End { get; set; }
        
        public CreateTimeEntryCommand IncludeProjectId(Guid id)
        {
            ProjectId = id;

            return this;
        }
        
        public CreateTimeEntryCommand IncludeProjectMemberId(Guid id)
        {
            ProjectMemberId = id;

            return this;
        }
    }
}