using AutoMapper;
using Business;
using WebApplication.ViewModels;

namespace WebApplication.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Desenvolvedor, DesenvolvedorViewModel>().ReverseMap();
            CreateMap<Projeto, ProjetoViewModel>().ReverseMap();
            CreateMap<LancamentoDeHora, LancamentoDeHoraViewModel>().ReverseMap();
            CreateMap<Ranking, RankingViewModel>().ReverseMap();
        }
    }
}