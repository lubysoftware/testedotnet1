namespace Luby.Core.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Luby.Core.Model;
    public interface IProjetoRepository : IRepository<Projeto>
    {
        /// <summary>
        /// Busca todos os Desenvolvedores de um Projeto
        /// </summary>
        /// <param name="id">Id do projeto</param>
        /// <returns></returns>
        Task<IEnumerable<Desenvolvedor>> GetDesenvolvedores(int id);

        /// <summary>
        /// Salva no banco de dados o lançamento de horas de um desenvolvedor em um projeto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task LancarHoras(ProjetoDesenvolvedores entity);
    }
}