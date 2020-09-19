using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    /// <summary>
    /// Interface do contrato do serviço do lançamento de horas
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface ILaunchTimeService : IDisposable
    {
        #region Methods
        Task<bool> Add(LaunchTime launchTime);
        Task<bool> Update(LaunchTime launchTime);
        Task<bool> Remove(Guid id);
        #endregion Methods
    }
}
