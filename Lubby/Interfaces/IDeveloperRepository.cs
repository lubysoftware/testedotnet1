using Lubby.Domain.Root;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Domain.Interfaces
{
    public interface IDeveloperRepository
    {
        Task Create(Developer dev);
        Task<Developer> Get(string identifier);
        Task<List<Developer>> List();
        Task Delete(string identifier);
        Task Update(Developer dev);
    }
}
