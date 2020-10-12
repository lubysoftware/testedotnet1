namespace Luby.Core.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Luby.Core.Model;
    public interface IDesenvolvedorRepository : IRepository<Desenvolvedor>
    {
        /// <summary>
        /// Busca todos os projetos que o desenvolvedor particida
        /// </summary>
        /// <param name="id">Id do desenvolvedor</param>
        /// <returns></returns>
        Task<IEnumerable<Projeto>> GetProjetos(int id);
    }
}