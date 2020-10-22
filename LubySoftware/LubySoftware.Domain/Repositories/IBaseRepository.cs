using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubySoftware.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task Save(T registerHour);
        Task Update(T registerHour);
        Task Delete(long id);
        Task<T> Find(long id);
        Task<IEnumerable<T>> FindAll();
    }
}
