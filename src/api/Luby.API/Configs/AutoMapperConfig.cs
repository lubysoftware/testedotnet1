namespace Luby.API.Configs
{
    using AutoMapper;
    using Luby.API.ViewModel;
    using Luby.Core.Model;
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Desenvolvedor, DesenvolvedorViewModel>().ReverseMap();
            CreateMap<Projeto, ProjetoViewModel>().ReverseMap();
        }
    }
}