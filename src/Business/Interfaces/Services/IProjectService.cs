using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    /// <summary>
    /// Interface de contrato do serviço do objeto projeto
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface IProjectService : IDisposable
    {
        #region Methods
        Task<bool> Add(Project project);
        Task<bool> Update(Project project);
        Task<bool> Remove(Guid id);
        #endregion Methods
    }
}
