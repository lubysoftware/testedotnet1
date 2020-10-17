using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        void Add(TEntidade obj);
        TEntidade GetById(int id);
        Task<TEntidade> GetByIdAsync(int id);
        IEnumerable<TEntidade> GetAll();
        Task<List<TEntidade>> GetAllAsync();
        void Update(TEntidade obj);
        void Remove(TEntidade obj);
        void Dispose();
    }
}
