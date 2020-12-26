using System.Threading.Tasks;
using test.domain.Entities;

namespace test.domain.Interfaces.Repositories
{
    public interface  IDeveloperRepository : IRepository<Developer>
    {
        Task<Developer> FindByLogin(string email);
    }
}
