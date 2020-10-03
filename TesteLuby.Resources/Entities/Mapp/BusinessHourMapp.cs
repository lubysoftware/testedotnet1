using TesteLuby.Domain.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using TesteLuby.Resources.Entities;

namespace Testeluby.ResourcesDB.Entities.Mapp
{
    public class BusinessHourMapp: DommelEntityMap<BusinessHour>, IMapper
    {
        public BusinessHourMapp()
        {
            ToTable("businesshour");
            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.DateTimeEnd).ToColumn("datetimeend");
            Map(x => x.DateTimeStart).ToColumn("datetimestart");
            Map(x => x.DeveloperId).ToColumn("developerid");
        }
    }
}
