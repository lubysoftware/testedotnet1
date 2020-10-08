using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity>
    {
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Create(TEntity entity);
        void CreateRange(List<TEntity> entities);
        void Remove(int id);
        void Remove(TEntity entity);
        void RemoveRange(List<TEntity> entities);
        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
