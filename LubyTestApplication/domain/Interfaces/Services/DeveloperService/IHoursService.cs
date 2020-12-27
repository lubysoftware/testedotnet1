using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.domain.Entities;

namespace test.domain.Interfaces.Services.DeveloperService
{
    public interface IHoursService
    {
        Task<Hours> Get(Guid id);
        IEnumerable<Hours> GetByDeveloper(string developer);
        Task<IEnumerable<Hours>> GetAll();
        Task<Hours> Post(Hours hours);
        Task<Hours> Put(Hours hours);
        Task<bool> Delete(Guid id);
    }
}
