using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IApplicationBase<TEntity, TEntityDTO> where TEntity : class where TEntityDTO : class 
    {
        void Update(TEntityDTO entity);
        void UpdateRange(List<TEntityDTO> entities);
        void Create(TEntityDTO entity);
        void CreateRange(List<TEntityDTO> entities);
        void Remove(int id);
        void Remove(TEntityDTO entity);
        void RemoveRange(List<TEntityDTO> entities);
        TEntityDTO GetById(int id);
        List<TEntityDTO> GetAll();
    }
}
