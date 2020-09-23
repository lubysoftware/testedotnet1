using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository, INotifier notifier) : base(notifier)
        {
            _projectRepository = projectRepository;
        }

        #region Methods
        public async Task<bool> Add(Project project)
        {
            if (!ExecuteValidation(new ProjectValidation(), project))
                return false;

            await _projectRepository.Add(project);

            return true;
        }

        public async Task<bool> Update(Project project)
        {
            if (!ExecuteValidation(new ProjectValidation(), project))
                return false;

            await _projectRepository.Update(project);

            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            if (_projectRepository.GetProjectLaunchTime(id).Result.LaunchTimes.Any())
            {
                Notify("Projeto contém horas lançadas");
                return false;
            }

            await _projectRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _projectRepository?.Dispose();
        }
        #endregion Methods
    }
}
