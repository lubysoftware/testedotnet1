using System.Collections.Generic;
using test.domain.Entities;

namespace test.domain.Interfaces.Repositories
{
    public interface IHoursRepository : IRepository<Hours>
    {
        IEnumerable<Hours> GetByDeveloper(string developer);
    }
}
