using Microsoft.AspNetCore.Mvc;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    /// <summary>
    /// Classe de redirecionamento para o Swagger
    /// </summary>
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