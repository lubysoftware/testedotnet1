using PontoAPI.Domain.Models;

namespace PontoAPI.Domain.Interfaces
{
    public interface IProjetoRepository
    {
         bool CreateProjeto(Projeto projeto);

         string GetProjeto(int projetoID);

         bool DeleteProjeto(int projetoID);

         bool EditProjeto(Projeto projeto);
    }
}