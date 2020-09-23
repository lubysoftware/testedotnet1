using API.ViewModel;
using AutoMapper;
using Business.Models;

namespace API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Developer, DeveloperViewModel>().ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
            CreateMap<LaunchTime, LaunchTimeViewModel>().ReverseMap();
        }
    }
}
