using LubyClocker.CrossCuting.Shared.ViewModels;
using LubyClocker.Domain.BoundedContexts.Developers;

namespace LubyClocker.Application.BoundedContexts.Developers.ViewModels
{
    public class DeveloperViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string Commentary { get; set; }
        public QualificationLevel Qualification { get; set; }

        public DeveloperViewModel()
        {
        }

        public DeveloperViewModel(Developer entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt;
            Commentary = entity.Commentary;
            Qualification = entity.Qualification;
            FullName = entity.FullName;
        }
    }
}