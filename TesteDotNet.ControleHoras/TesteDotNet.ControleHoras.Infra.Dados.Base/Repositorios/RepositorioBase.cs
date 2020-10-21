using Infra.Dados.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;

namespace Infra.Dados.Base
{
    public abstract class RepositorioBase<TEntidade> : IDisposable, IRepositorioBase<TEntidade> where TEntidade : class
    {
        private readonly DbContexto _dbContexto;

        public RepositorioBase(DbContexto Context)
        {
            _dbContexto = Context;
        }

        public virtual void Add(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Add(obj);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task AddAsync(TEntidade obj)
        {
            try
            {
                await _dbContexto.Set<TEntidade>().AddAsync(obj);
                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntidade GetById(int id)
        {
            return _dbContexto.Set<TEntidade>().Find(id);
        }
        public virtual async Task<TEntidade> GetByIdAsync(int id)
        {
            return await _dbContexto.Set<TEntidade>().FindAsync(id);
        }

        public virtual IEnumerable<TEntidade> GetAll()
        {
           return _dbContexto.Set<TEntidade>().ToList();
        }
        public virtual async Task<List<TEntidade>> GetAllAsync()
        {
            return await _dbContexto.Set<TEntidade>().AsNoTracking().ToListAsync();
        }

        public virtual void Update(TEntidade obj)
        {
            try
            {
                if (_dbContexto.Entry(obj).State == EntityState.Detached)
                {
                    _dbContexto.Attach(obj);
                    _dbContexto.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    _dbContexto.Update(obj);
                }
                    
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public virtual async Task UpdateAsync(TEntidade obj)
        {
            try
            {
                if (_dbContexto.Entry(obj).State == EntityState.Detached)
                {
                    _dbContexto.Attach(obj);
                    _dbContexto.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    _dbContexto.Update(obj);
                }

                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void Remove(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Remove(obj);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task RemoveAsync(TEntidade obj)
        {
            try
            {
                _dbContexto.Set<TEntidade>().Remove(obj);
                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Dispose()
        {
            _dbContexto.Dispose();
        }

        public abstract bool Exists(int id);
        public abstract Task<bool> ExistsAsync(int id);
    }
}
