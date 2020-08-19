using LancamentoHorasAPI.Dto;
using LancamentoHorasAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Interfaces
{
    public interface IDesenvolvedorService
    {
        /// <summary>
        /// Obtém a lista do ranking dos 5 desenvolvedores que mais possuem horas trabalhadas
        /// </summary>
        /// <returns>Retorna a lista dos desenvolvedores</returns>
        Task<IEnumerable<DesenvolvedorRankResult>> GetTop5Async();

        /// <summary>
        /// Obtém a lista de todos desenvolvedores
        /// </summary>
        /// <returns>Retorna a lista de todos desenvolvedores</returns>
        Task<List<Desenvolvedor>> FindAllAsync();

        /// <summary>
        ///  Obtém um desenvolvedor pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um Desenvolvedor</returns>
        Task<Desenvolvedor> FindByIdAsync(int id);

        /// <summary>
        /// Atualiza os dados de um desenvolvedor
        /// </summary>
        /// <param name="desenvolvedor"></param>
        Task UpdateAsync(Desenvolvedor desenvolvedor);

        /// <summary>
        /// Insere um desenvolvedor no banco de dados
        /// </summary>
        /// <param name="desenvolvedor"></param>
        Task InsertAsync(DesenvolvedorPost desenvolvedor);

        /// <summary>
        /// Remove um desenvolvedor no banco de dados
        /// </summary>
        /// <param name="id"></param>
        Task RemoveAsync(int id);


    }
}
