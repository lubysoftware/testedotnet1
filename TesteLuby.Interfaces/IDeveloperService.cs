using System.Collections.Generic;
using TesteLuby.Data.Entities;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Interfaces
{
    public interface IDeveloperService : IBaseService<DeveloperDTO>
    {
        IEnumerable<DeveloperDTO> GetByName(string name);
    }
}
