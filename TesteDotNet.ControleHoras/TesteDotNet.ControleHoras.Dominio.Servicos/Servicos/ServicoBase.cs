using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Entidades;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;

namespace TesteDotNet.ControleHoras.Dominio.Servicos
{
    public abstract class ServicoBase<TEntidade> : IDisposable, IServicoBase<TEntidade> where TEntidade : class
    {
        private readonly IRepositorioBase<TEntidade> _repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(TEntidade obj)
        {            
            _repositorio.Add(obj);
        }

        public IEnumerable<TEntidade> GetAll()
        {
            return _repositorio.GetAll();
        }

        public Task<List<TEntidade>> GetAllAsync()
        {
            return _repositorio.GetAllAsync();
        }

        public TEntidade GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public Task<TEntidade> GetByIdAsync(int id)
        {
            return _repositorio.GetByIdAsync(id);
        }

        public void Remove(TEntidade obj)
        {
            _repositorio.Remove(obj);
        }

        public void Update(TEntidade obj)
        {
            _repositorio.Update(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public bool Exists(int id)
        {
            return _repositorio.Exists(id);
        }
    }
}
