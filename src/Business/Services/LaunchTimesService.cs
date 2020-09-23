using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LaunchTimesService : BaseService, ILaunchTimeService
    {
        private readonly ILaunchTimeRepository _launchTimeRepository;
        
        public LaunchTimesService(ILaunchTimeRepository launchTimeRepository, INotifier notifier) : base(notifier)
        {
            _launchTimeRepository = launchTimeRepository;
        }

        public async Task<bool> Add(LaunchTime launchTime)
        {
            if(launchTime.IdDeveloper == null)
            {
                Notify("Não informado um desenvolvedor válido");
                return false;
            }

            if(launchTime.IdProject == null)
            {
                Notify("Não informado um projeto valido");
                return false;
            }

            await _launchTimeRepository.Add(launchTime);

            return true;
        }

        public void Dispose()
        {
            _launchTimeRepository?.Dispose();
        }

        public async Task<bool> Remove(Guid id)
        {
            await _launchTimeRepository.Remove(id);

            return true;
        }

        public async Task<bool> Update(LaunchTime launchTime)
        {
            await _launchTimeRepository.Update(launchTime);

            return true;
        }
    }
}
