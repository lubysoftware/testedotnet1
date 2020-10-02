using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    /// <summary>
    /// Interface do contrato do repositorio do objeto desenvolvedor, implementar as opçoes especificas
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> GetByIdToRemove(Guid id);
    }
}
