using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using test.domain.Entities;


namespace test.domain.Interfaces.Services.DeveloperService
{
    public interface IDeveloperService
    {
        Task<Developer> Get(Guid id);
        Task<IEnumerable<Developer>> GetAll();
        Task<Developer> Post(Developer developer);
        Task<Developer> Put(Developer developer);
        Task<bool> Delete(Guid id);
    }
}
