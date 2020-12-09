using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILancamentoDeHoraRepository : IRepository<LancamentoDeHora>
    {
        Task<List<Ranking>> ObterRank();
    }
}