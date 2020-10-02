using TesteLuby.Domain.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using TesteLuby.Resources.Entities;

namespace Testeluby.ResourcesDB.Entities.Mapp
{
    public class ProjectMapp : DommelEntityMap<Project>, IMapper
    {
        public ProjectMapp()
        {
            ToTable("project");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.ProjectName).ToColumn("projectname");
        }
    }
}
