using Dapper.FluentMap.Dommel.Mapping;
using TesteLuby.Domain.Models.Entities;
using TesteLuby.Resources.Entities;

namespace Testeluby.ResourcesDB.Entities.Mapp
{
    public class ProjectDeveloperMapp : DommelEntityMap<ProjectDeveloper>, IMapper
    {
        public ProjectDeveloperMapp()
        {
            ToTable("projectdeveloper");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.ProjectId).ToColumn("projectid");
            Map(x => x.DeveloperId).ToColumn("developerid");
        }
    }
}