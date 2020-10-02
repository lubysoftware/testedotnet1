using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.Repository
{
    /// <summary>
    /// Interface de cotrato do repositorio do objeto lançamento de horas (LaunchTime.cs), implementar operações específicas
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface ILaunchTimeRepository : IRepository<LaunchTime>
    {
        Task<LaunchTime> GetByIdToRemove(Guid id);
    }
}
