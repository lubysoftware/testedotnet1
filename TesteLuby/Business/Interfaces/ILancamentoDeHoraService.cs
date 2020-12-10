using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILancamentoDeHoraService : IDisposable
    {
        Task<bool> Adicionar(LancamentoDeHora lancamentoDeHora);
        Task<bool> Atualizar(LancamentoDeHora lancamentoDeHora);
        Task<bool> Remover(Guid id);
    }
}