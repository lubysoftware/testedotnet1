using System;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.AddMember
{
    public class AddMemberProjectCommand : Command<ProjectMemberViewModel>
    {
        public Guid ProjectId { get; internal set; }
        public Guid DeveloperId { get; set; }
        public DateTime EntryDate { get; set; }
        
        public AddMemberProjectCommand IncludeProjectId(Guid id)
        {
            ProjectId = id;

            return this;
        }
    }
}