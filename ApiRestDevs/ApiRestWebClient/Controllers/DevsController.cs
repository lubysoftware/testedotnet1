using ApiRestWebClient.Models.ViewModels;
using ApiRestWebClient.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestWebClient.Controllers
{
    public class DevsController : Controller
    {
        public IActionResult Index()
        {
            var apiMethods = new ApiMethods();
            var devs = apiMethods.RetornaDevs();
            var retorno = devs.Select(x => new DevsViewModel()
            {
                Id = x.Id,
                Nome = x.Nome

            });

            return View(retorno);
        }
    }
}
