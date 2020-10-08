using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repo;

        public ServiceBase(IRepositoryBase<TEntity> repo)
        {
            _repo = repo;
        }

        public void Create(TEntity entity)
        {
            _repo.Create(entity);
        }

        public void CreateRange(List<TEntity> entities)
        {
            _repo.CreateRange(entities);
        }

        public List<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }

        public void Remove(TEntity entity)
        {
            _repo.Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _repo.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _repo.UpdateRange(entities);
        }
    }
}
