using System;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared.ViewModels;
using LubyClocker.Domain.BoundedContexts.Projects;

namespace LubyClocker.Application.BoundedContexts.Projects.ViewModels
{
    public class ProjectMemberViewModel : BaseViewModel
    {
        public DateTime EntryDate { get; set; }
        public DeveloperViewModel Developer { get; set; }

        public ProjectMemberViewModel()
        {
        }
        
        public ProjectMemberViewModel(ProjectMember entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt;
            EntryDate = entity.EntryDate;
            Developer = new DeveloperViewModel(entity.Developer);
        }
    }
}