using AutoMapper;
using LTS.Domain.Commands.Developer;
using LTS.Domain.Commands.Project;
using LTS.Domain.Commands.TimeSheet;
using LTS.Domain.Entities;

namespace LTS.API.Configuration.AutoMapper.Profiles
{
    public class CommandToEntity : Profile
    {
        public CommandToEntity()
        {
            CreateMap<CreateDeveloperCommand, Developer>().ReverseMap();
            CreateMap<UpdateDeveloperCommand, Developer>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>().ReverseMap();
            CreateMap<UpdateProjectCommand, Project>().ReverseMap();
            CreateMap<CreateTimeSheetCommand, TimeSheet>().ReverseMap();
            CreateMap<UpdateTimeSheetCommand, TimeSheet>().ReverseMap();

        }
    }
}
