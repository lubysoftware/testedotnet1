using TesteLuby.Domain.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace TesteLuby.Resources.Entities.Mapp
{
    public class DeveloperMapp : DommelEntityMap<Developer>, IMapper
    {
        public DeveloperMapp()
        {
            ToTable("projects");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.UserName).ToColumn("username");
            Map(x => x.Email).ToColumn("email");
        }
    }
}