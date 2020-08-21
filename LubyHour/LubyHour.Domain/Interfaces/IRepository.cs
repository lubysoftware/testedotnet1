using LubyHour.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LubyHour.Domain.Interfaces
{
    public interface IRepository
    {
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
        Task<Entity> GetAll();
        Task<Entity> GetById(Guid id);

    }
}