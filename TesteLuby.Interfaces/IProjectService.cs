using System.Collections.Generic;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Interfaces
{
    public interface IProjectService : IBaseService<ProjectDTO>
    {
        IEnumerable<ProjectDTO> GetByName(string name);
    }
}
