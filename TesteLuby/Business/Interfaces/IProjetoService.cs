using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProjetoService : IDisposable
    {
        Task<bool> Adicionar(Projeto projeto);
        Task<bool> Atualizar(Projeto projeto);
        Task<bool> Remover(Guid id);
    }
}