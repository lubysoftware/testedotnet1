using System;
using System.ComponentModel.DataAnnotations;
using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.CrossCuting.Shared.Common;
using LubyClocker.CrossCuting.Shared.Validators;
using LubyClocker.Domain.BoundedContexts.Developers;

namespace LubyClocker.Application.BoundedContexts.Developers.Commands.Update
{
    public class UpdateDeveloperCommand : BasicCommand<DeveloperViewModel>
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Commentary { get; set; }
        [RequiredEnum]
        public QualificationLevel Qualification { get; set; }
    }
}