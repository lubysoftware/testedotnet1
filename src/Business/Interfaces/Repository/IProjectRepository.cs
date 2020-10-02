using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    /// <summary>
    /// Interface de contrato do repositorio do objeto projeto, implementar operações especificas
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface IProjectRepository: IRepository<Project>
    {
        Task<Project> GetProjectLaunchTime(Guid id);

        Task<Project> GetProjectByIdToRemove(Guid id);
    }
}
