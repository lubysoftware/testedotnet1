using Aplicacao.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Principal.Interfaces
{
    public interface IAppServicoRegistroHorasRanking
    {
        Task<RegistroHoraRankingDTO> GetSemanaComMaisHorasTrabalhadas(int numeroDesenvolvedoresNoRanking);
    }
}
