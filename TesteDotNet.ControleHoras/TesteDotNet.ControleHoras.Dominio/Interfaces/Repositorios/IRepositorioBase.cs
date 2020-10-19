using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : class
    {
        void Add(TEntidade obj);
        Task AddAsync(TEntidade obj);
        TEntidade GetById(int id);
        Task<TEntidade> GetByIdAsync(int id);
        IEnumerable<TEntidade> GetAll();
        Task<List<TEntidade>> GetAllAsync();
        void Update(TEntidade obj);
        Task UpdateAsync(TEntidade obj);
        void Remove(TEntidade obj);
        Task RemoveAsync(TEntidade obj);
        bool Exists(int id);
        Task<bool> ExistsAsync(int id);
        void Dispose();
    }
}
