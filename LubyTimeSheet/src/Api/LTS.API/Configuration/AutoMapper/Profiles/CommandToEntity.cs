using AutoMapper;
using LTS.Domain.Commands.Developer;
using LTS.Domain.Entities;

namespace LTS.API.Configuration.AutoMapper.Profiles
{
    public class CommandToEntity : Profile
    {
        public CommandToEntity()
        {
            CreateMap<CreateDeveloperCommand, Developer>().ReverseMap();
            CreateMap<UpdateDeveloperCommand, Developer>().ReverseMap();
            
        }
    }
}
