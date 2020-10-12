namespace Luby.Core.Interfaces.Repositories
{   
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Luby.Core.Model;
    public interface IRepository<T> : IDisposable 
        where T : Entity
    {
        /// <summary>
        /// Busca todos os registros da Entidade
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Busca o registro de uma entidade
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns></returns>
        Task<T> GetbyId(int id);

        /// <summary>
        /// Adiciona ou Atualiza caso a entidade já existir no banco
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Save(T entity);

        /// <summary>
        /// Deleta um registro do banco de dados
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns></returns>
        Task Delete(int id);

        /// <summary>
        /// Busca o entidade de acordo com o predicato
        /// </summary>
        /// <param name="precidate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> Seach(Expression<Func<T, bool>> precidate);

        /// <summary>
        /// Salva o contexto do banco de dados
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChange();
    }
}