using Api.Autenticacao;
using Aplicacao.DTO.DTO;
using Aplicacao.Principal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("login")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAppServicoAutenticacao _servicoAutenticacao;
        private readonly IConfiguration _config;

        public AutenticacaoController(IAppServicoAutenticacao servicoAutenticacao, IConfiguration configuration)
        {
            _servicoAutenticacao = servicoAutenticacao;
            _config = configuration;
        }
                
        [HttpPost]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                // Obtém o usuário.
                var resultado = await _servicoAutenticacao.GetUsuario(usuarioDTO);

                // Não encontrado.
                if (resultado.Role == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                //Gera o token.
                string token = TokenService.GerarToken(_config, resultado);

                usuarioDTO.Senha = "";
                return new
                {
                    usuarioDTO,
                    token
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
