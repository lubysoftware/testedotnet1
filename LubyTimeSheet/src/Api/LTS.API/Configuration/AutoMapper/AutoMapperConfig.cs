using AutoMapper;
using LTS.API.Configuration.AutoMapper.Profiles;

namespace LTS.API.Configuration.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToEntity());
            });
        }
    }
}
