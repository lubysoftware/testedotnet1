using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    /// <summary>
    /// Classe de serviço do desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class DeveloperService : BaseService, IDeveloperService
    {
        #region Attributes
        private readonly IDeveloperRepository _developerRepository;
        #endregion Attributes

        #region Constructor
        public DeveloperService(IDeveloperRepository developerRepository, INotifier notifier) : base(notifier)
        {
            _developerRepository = developerRepository;
        }
        #endregion Constructor

        #region Methods
        public async Task Add(Developer developer)
        {
            if (!ExecuteValidation(new DeveloperValidation(), developer))
                return;

            await _developerRepository.Add(developer);
        }

        public async Task Remove(Guid id)
        {
            await _developerRepository.Remove(id);
        }

        public async Task Update(Developer developer)
        {
            if (!ExecuteValidation(new DeveloperValidation(), developer))
                return;

            await _developerRepository.Update(developer);
        }

        public void Dispose()
        {
            _developerRepository?.Dispose();
        }
        #endregion Methods
    }
}
