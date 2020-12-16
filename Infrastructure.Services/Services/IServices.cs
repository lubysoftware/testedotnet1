using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IServices<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> GetById(int id);
        Task<T> Post(T entity);
        Task<T> Put(int id, T entity);
        Task<T> Delete(int id);
        string SetEndpoint(string endpoint);
    }
}
