using LubyClocker.Application.BoundedContexts.Developers.ViewModels;
using LubyClocker.Domain.BoundedContexts.Developers;
using MediatR;

namespace LubyClocker.Application.BoundedContexts.Developers.Create
{
    public class CreateDeveloperCommand : IRequest<DeveloperViewModel>
    {
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public QualificationLevel Qualification { get; set; }
    }
}