using TesteLuby.Domain.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using TesteLuby.Resources.Entities;

namespace Testeluby.ResourcesDB.Entities.Mapp
{
    public class BusinessHourMapp: DommelEntityMap<Developer>, IMapper
    {
        public BusinessHourMapp()
        {
            ToTable("businesshour");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.UserName).ToColumn("username");
            Map(x => x.Email).ToColumn("email");
            Map(x => x.Password).ToColumn("password");
        }
    }
}
