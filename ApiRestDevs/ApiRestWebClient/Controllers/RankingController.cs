using ApiRestWebClient.Models.ViewModels;
using ApiRestWebClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiRestWebClient.Controllers
{
    public class RankingController : Controller
    {
        public IActionResult Index()
        {
            var apiMethods = new ApiMethods();
            var ranking = apiMethods.RetornaRanking();
            var retorno = ranking.Select(x => new RankingViewModel()
            {
                NomeDoDesenvolvedor = x.NomeDoDesenvolvedor,
                PosicaoDoRanking = x.PosicaoDoRanking,
                MediaDeHoras = x.MediaDeHoras             
            });

            return View(retorno);
        }
    }
}
