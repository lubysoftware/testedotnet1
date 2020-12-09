using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDesenvolvedorService : IDisposable
    {
        Task<bool> Adicionar(Desenvolvedor desenvolvedor);
        Task<bool> Atualizar(Desenvolvedor desenvolvedor);
        Task<bool> Remover(Guid id);
    }
}