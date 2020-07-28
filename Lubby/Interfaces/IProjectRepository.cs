using Lubby.Domain.Root;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task  Create(Project project);
        Task<Project> Get(string identifier);
        Task<List<Project>> List();
        Task Delete(string identifier);
        Task Update(Project project);
    }
}
