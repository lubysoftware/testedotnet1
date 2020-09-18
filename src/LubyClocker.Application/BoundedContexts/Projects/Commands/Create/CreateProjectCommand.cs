using System;
using System.ComponentModel.DataAnnotations;
using LubyClocker.Application.BoundedContexts.Projects.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.CrossCuting.Shared.Validators;

namespace LubyClocker.Application.BoundedContexts.Projects.Commands.Create
{
    public class CreateProjectCommand : BasicCommand<ProjectViewModel>
    {
        [Required]
        public string Name { get; set; }
        [RequiredDateTime]
        public DateTime StartDate { get; set; }
        [RequiredDateTime]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string Description { get; set; }
    }
}