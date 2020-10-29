using Luby.Models;
using Luby.Repositorios;
using Luby.Util;
using Luby.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Luby.Controllers
{
    [Produces("application/json")]
    [Route("api/desenvolvedor")]
    public class DesenvolvedorController : BaseController
    {
        private readonly Context _context;
        private IConfiguration _config;
        IHttpContextAccessor accessor;
        private readonly IHostingEnvironment environment;
        DesenvolvedorRepositorio _desenvolvedorRepositorio;

        public DesenvolvedorController(IConfiguration config, Context context, IHttpContextAccessor accessor, IHostingEnvironment environment) : base(config, context, accessor)
        {
            _config = config;
            _context = context;
            _desenvolvedorRepositorio = new DesenvolvedorRepositorio(_context);
            this.accessor = accessor;
            this.environment = environment;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                IActionResult response = Unauthorized();

                response = await Autentica(model.Email, model.Senha, response);

                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private async Task<IActionResult> Autentica(string email, string senha, IActionResult response)
        {
            string senhaCrypt = Security.encryptSHA256(senha);

            Desenvolvedor obj = await _desenvolvedorRepositorio.LoginAsync(email, senhaCrypt);
            if (obj != null)
            {
                var tokenString = GenerateJSONWebToken(obj);
                DesenvolvedorViewModel _obj = await getUser(obj.Id);
                _obj.Senha = "";

                response = Ok(new { token = tokenString, id = obj.Id });
            }

            return response;
        }

        private string GenerateJSONWebToken(Desenvolvedor userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenConfigurations:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["TokenConfigurations:Issuer"],
              _config["TokenConfigurations:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);
            token.Payload["user"] = JsonConvert.SerializeObject(userInfo.MergeObjects(new DesenvolvedorViewModel()));
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private async Task<DesenvolvedorViewModel> getUser(int id)
        {
            var obj = await _context.Set<Desenvolvedor>().FirstOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                return null;

            DesenvolvedorViewModel user = obj.MergeObjects(new DesenvolvedorViewModel());
            user.Senha = null;

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Desenvolvedor model)
        {
            try
            {
                if (_desenvolvedorRepositorio.FindBy(p => p.Email == model.Email).Count() > 0)
                    return ReturnBadRequest("Email", "E-mail já cadastrado");



                model.Senha = Security.encryptSHA256(model.Senha);

                

                await _desenvolvedorRepositorio.AddAndSaveAsync(model);

             
                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Desenvolvedor> list = _desenvolvedorRepositorio.GetAll().ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                Desenvolvedor desenvolvedor = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (desenvolvedor == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                return Ok(desenvolvedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [Authorize, HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] Desenvolvedor desenvolvedor, int id)
        {
            try
            {
                Desenvolvedor busca = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (busca == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                busca.Nome = desenvolvedor.Nome;
                busca.Email = desenvolvedor.Email;

                await _desenvolvedorRepositorio.EditAndSaveAsync(busca);

                return Ok(busca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                Desenvolvedor busca = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (busca == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                _desenvolvedorRepositorio.Delete(busca);

                return Ok("Desenvolvedor apagado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
