using PontoAPI.Domain.Models;
using System.Collections.Generic;

namespace PontoAPI.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
         bool Create(Lancamento lancamento);

         string GetLancamentos();

        string RankingSemanal();
    }
}