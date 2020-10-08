using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ApplicationBase<TEntity, TEntityDTO> : IApplicationBase<TEntity, TEntityDTO>
        where TEntity : class
        where TEntityDTO : class
    {
        protected readonly IServiceBase<TEntity> _service;
        protected readonly IMapper _map;
        public ApplicationBase(IMapper map, IServiceBase<TEntity> service)
        {
            _service = service;
            map = _map;
        }

        public void Create(TEntityDTO entity)
        {
            _service.Create(_map.Map<TEntity>(entity));
        }

        public void CreateRange(List<TEntityDTO> entities)
        {
            _service.CreateRange(_map.Map<List<TEntity>>(entities));
        }

        public List<TEntityDTO> GetAll()
        {
            return _map.Map<List<TEntityDTO>>(_service.GetAll());
        }

        public TEntityDTO GetById(int id)
        {
            return _map.Map<TEntityDTO>(_service.GetById(id));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Remove(TEntityDTO entity)
        {
            _service.Remove(_map.Map<TEntity>(entity));
        }

        public void RemoveRange(List<TEntityDTO> entities)
        {
            _service.RemoveRange(_map.Map<List<TEntity>>(entities));
        }

        public void Update(TEntityDTO entity)
        {
            _service.Update(_map.Map<TEntity>(entity));
        }

        public void UpdateRange(List<TEntityDTO> entities)
        {
            _service.UpdateRange(_map.Map<List<TEntity>>(entities));
        }
    }
}
