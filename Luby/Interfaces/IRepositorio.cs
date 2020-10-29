
using Luby.Generics;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Interfaces
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> FindAsync(int id);
        T Find(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
        Task SaveAsync();
    }
}
