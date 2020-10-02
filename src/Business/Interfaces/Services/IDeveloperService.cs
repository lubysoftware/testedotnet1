using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    /// <summary>
    /// Interface de contrato do serviço do objeto desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface IDeveloperService : IDisposable
    {
        #region Methods
        Task Add(Developer developer);
        Task Update(Developer developer);
        Task Remove(Guid id);
        #endregion Methods
    }
}
