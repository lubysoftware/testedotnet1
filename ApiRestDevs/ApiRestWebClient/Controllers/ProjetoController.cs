using ApiRestWebClient.Models.ViewModels;
using ApiRestWebClient.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiRestWebClient.Controllers
{
    public class ProjetoController : Controller
    {
        public IActionResult Index()
        {
            var apiMethods = new ApiMethods();
            var projetos = apiMethods.RetornaProjetos();
            var retorno = projetos.Select(x => new ProjetoViewModel()
            {
                Id = x.Id,
                Nome = x.Nome

            });

            return View(retorno);
        }
    }
}
