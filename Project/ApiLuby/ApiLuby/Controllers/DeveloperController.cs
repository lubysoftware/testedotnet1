using ApiLuby.Business.Entities;
using ApiLuby.Business.Entities.Repositories;
using ApiLuby.Configurations;
using ApiLuby.Filters;
using ApiLuby.Infrastructure.Data;
using ApiLuby.Infrastructure.Data.Repositories;
using ApiLuby.Models;
using ApiLuby.Models.Developers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiLuby.Controllers
{
    [Route("api/v1/developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {

        private readonly IDeveloperRepository _developerRepository;
        
        public readonly IAuthenticationService _authenticationService;

        public DeveloperController(IDeveloperRepository developerRepository, IAuthenticationService authenticationService)
        {
            _developerRepository = developerRepository;
            
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo(token válido por 5 minutos!)
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do developer e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidationFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenericViewModel))]
        [HttpPost]
        [Route("login")]
        [CustomModelStateValidation]
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {
            var developer = _developerRepository.GetDeveloper(loginViewModelInput.Login);

            if (developer == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            //if(user.Password != loginViewModel.Password.GerarSenhaCriptografada())
            // {
            //     return BadRequest("Houve um erro ao tentar acessar.");
            // }
            var developerViewModelOutput = new DeveloperViewModelOutput()
            {
                Codigo = developer.Codigo,
                Login = loginViewModelInput.Login,
                Email = developer.Email
                //preciso tb buscar o total de horas no banco!
            };


            var token = _authenticationService.GetToken(developerViewModelOutput);

            return Ok(new
            {
                Token = token,
                developer = developerViewModelOutput
            });
        }

        /// <summary>
        /// Este serviço permite cria um desenvolvedor não existente.
        /// </summary>
        /// <param name="loginViewModelInput">"View model do registro de login</param>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidationFieldViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenericViewModel))]
        [HttpPost]
        [Route("register")]
        [CustomModelStateValidation]
        public IActionResult Register(RegisterViewModelInput loginViewModelInput)
        {

            //   

            //   var pendingMigrations = contexto.Database.GetPendingMigrations();

            //   if (pendingMigrations.Count() > 0)
            //    {
            //        contexto.Database.Migrate();
            //    }


            var developer = new Developer();
            developer.Login = loginViewModelInput.Login;
            developer.Password = loginViewModelInput.Password;
            developer.Email = loginViewModelInput.Email;
            _developerRepository.Add(developer);
            _developerRepository.Commit();

            return Created("", loginViewModelInput);
        }
    }
}
