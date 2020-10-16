using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManager.Domain.Entities.Developer;

namespace TimeSheetManager.Domain.Repositories {
    public interface IDeveloperRepository {
        Task Post(Developer developer);
        Task<Developer> Get(Guid id);
        Task<List<Developer>> GetAll();
        Task Update(Developer developer);
        Task Delete(Guid id);
    }
}