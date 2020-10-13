namespace Luby.Core.Interfaces.Services
{
    using Luby.Core.Model;
    using System;
    using System.Threading.Tasks;
    public interface IBaseService<T> : IDisposable
        where T : Entity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}