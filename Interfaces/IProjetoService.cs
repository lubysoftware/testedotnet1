using LancamentoHorasAPI.Dto;
using LancamentoHorasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Interfaces
{
    public interface IProjetoService
    {
        /// <summary>
        /// Realiza lançamento de horas para um projeto
        /// </summary>
        /// <param name="projetoId"></param>
        /// <param name="lancamentoPost"></param>
        /// <returns></returns>
        Task InsertHorasAsync(int projetoId, LancamentoPost lancamentoPost);

        /// <summary>
        /// Obtém a lista de todos projetos
        /// </summary>
        /// <returns>Retorna a lista de todos projetos</returns>
        Task<List<Projeto>> FindAllAsync();

        /// <summary>
        /// Obtém um projeto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Projeto</returns>
        Task<Projeto> FindByIdAsync(int id);

        /// <summary>
        /// Atualiza os dados de um projeto no banco de dados
        /// </summary>
        /// <param name="projeto"></param>
        Task UpdateAsync(Projeto projeto);

        /// <summary>
        /// Insere um novo projeto no banco de dados
        /// </summary>
        /// <param name="projetoPost"></param>
        Task InsertAsync(ProjetoPost projetoPost);

        /// <summary>
        /// Remove um projeto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        Task RemoveAsync(int id);
    }
}
