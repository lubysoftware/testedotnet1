using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubyPontoEletronico.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class PessoaController : ControllerBase<Pessoa, PessoaDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IPessoaApplication pessoaApplication;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public PessoaController(IPessoaApplication app) : base(app)
        {
            pessoaApplication = app;
        }

        /// <summary>
        /// Autenticação do usuário
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO data)
        {
            try
            {
                return Ok(pessoaApplication.Login(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
