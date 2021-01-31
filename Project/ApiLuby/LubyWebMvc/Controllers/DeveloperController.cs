using LubyWebMvc.Models.Developers;
using LubyWebMvc.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LubyWebMvc.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDeveloperViewModelInput registerDeveloperViewModelInput)
        {
            try
            {
                var developer = await _developerService.Register(registerDeveloperViewModelInput);
                ModelState.AddModelError("", $"Os dados foram cadastrados com sucesso para o login {developer.Login}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            //var clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //var httpClient = new HttpClient(clientHandler);
            //httpClient.BaseAddress = new Uri("https://localhost:5001/");
            //var registerDeveloperViewModelInputJson = JsonConvert.SerializeObject(registerDeveloperViewModelInput);
            //var httpContent = new StringContent(registerDeveloperViewModelInputJson, Encoding.UTF8, "application/json");
            //var httpPost = httpClient.PostAsync("/api/v1/developer/register", httpContent).GetAwaiter().GetResult();

            //if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
            //{

            //    ModelState.AddModelError("", "Os dados foram cadastrados com sucesso");
            //}
            //else
            //{

            //    
            //}

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModelInput loginViewModelInput)
        {

            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                var developer = await _developerService.Login(loginViewModelInput);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, developer.Developer.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, developer.Developer.Login),
                    new Claim(ClaimTypes.Email, developer.Developer.Email),
                    new Claim("token", developer.Token),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddMinutes(5))
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                ModelState.AddModelError("", $"O usuário está autenticado {developer.Token}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }

            return View();
        }
    }
}
