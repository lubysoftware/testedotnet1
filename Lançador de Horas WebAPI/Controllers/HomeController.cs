using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        /// <summary>
        /// Redireciona para a página do Swagger
        /// </summary>
        /// <returns>Retornar um acão de redirecionamento</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("swagger");
        }
    }
}