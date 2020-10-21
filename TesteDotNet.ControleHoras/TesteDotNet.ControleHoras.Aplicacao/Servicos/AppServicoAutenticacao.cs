using Aplicacao.DTO.DTO;
using Aplicacao.Principal.Interfaces;
using AutoMapper;
using Dominio.Principal.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Principal.Servicos
{
    public class AppServicoAutenticacao : IAppServicoAutenticacao
    {
        private readonly IServicoUsuario _servicoUsuario;
        private readonly IMapper _mapper;

        public AppServicoAutenticacao(IServicoUsuario servicoUsuario, IMapper mapper)
        {
            _servicoUsuario = servicoUsuario;
            _mapper = mapper;
        }

        public Task<UsuarioDTO> GetUsuario(UsuarioDTO usuarioDTO)
        {
            //Busca o usuário. Retornará 'nulo' se não encontrar.
            var usuario = _servicoUsuario.GetByUsuarioSenha(usuarioDTO.NomeUsuario, usuarioDTO.Senha);

            if (usuario.Result == null)
                return Task.FromResult(new UsuarioDTO());

            var usuarioRetornoDTO = _mapper.Map<UsuarioDTO>(usuario.Result);
            return Task.FromResult(usuarioRetornoDTO);
        }
    }
}
