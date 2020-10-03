using TesteLuby.Domain.Models.Entities;

namespace TesteLuby.Domain.Contracts
{
    public interface IContext
    {
        IDapperRepository<Developer> Developer { get; set; }
        IDapperRepository<Project> Project { get; set; }
    }
}
