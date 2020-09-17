using LubyClocker.CrossCuting.Shared.ViewModels;
using LubyClocker.Domain.BoundedContexts.Developers;

namespace LubyClocker.Application.BoundedContexts.Developers.ViewModels
{
    public class DeveloperViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public QualificationLevel Qualification { get; set; }
    }
}