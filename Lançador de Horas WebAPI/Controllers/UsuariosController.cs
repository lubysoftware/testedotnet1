using Lançador_de_Horas_WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    /// <summary>
    /// API CRUD para Usuários
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="userManager">Gerenciador de usuário</param>
        /// <param name="signInManager">Gerenciador de Login</param>
        /// <param name="configuration">Configuração do serviço</param>
        public UsuariosController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna um objeto do tipo Claim
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return " << Controlador UsuariosController :: WebApiUsuarios >> ";
        }

        /// <summary>
        /// Insere um usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "email": "exemplo@exemplo.com",
        ///        "password": "123ABC-abc"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Objeto identity contido no body</param>
        /// <returns>O usuário criado</returns>
        /// /// <response code="201">Retorna o novo usuário criado</response>
        /// <response code="400">Se o usuário for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPost("Criar")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }

        /// <summary>
        /// Obtém um token para acesso a api
        /// </summary>
        /// <param name="userInfo">Objeto identity contido no body</param>
        /// <returns>Retorna um token e uma tempo de expiração</returns>
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "login inválido.");
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Gera um novo token
        /// </summary>
        /// <param name="userInfo">Objeto identity</param>
        /// <returns>Retorna um novo token com tempo de expiração</returns>
        private UserToken BuildToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("meuValor", "oque voce quiser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 5 minutos
            var expiration = DateTime.Now.AddMinutes(5);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}