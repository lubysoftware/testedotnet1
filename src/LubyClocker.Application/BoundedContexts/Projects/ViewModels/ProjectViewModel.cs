using System;
using LubyClocker.CrossCuting.Shared.ViewModels;
using LubyClocker.Domain.BoundedContexts.Projects;

namespace LubyClocker.Application.BoundedContexts.Projects.ViewModels
{
    public class ProjectViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }

        public ProjectViewModel()
        {
        }

        public ProjectViewModel(Project entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt;
            Name = entity.Name;
            StartDate = entity.StartDate;
            DeliveryDate = entity.DeliveryDate;
            Description = entity.Description;
        }
    }
}