using ApiRestWebClient.Models.ViewModels;
using ApiRestWebClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestWebClient.Controllers
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new TokenViewModel();
            var apiMethods = new ApiMethods();
            var token = apiMethods.RetornaToken();
            viewModel.Token = token.Token;
            viewModel.User = token.User;
            
            return View(viewModel);
        }
    }
}
