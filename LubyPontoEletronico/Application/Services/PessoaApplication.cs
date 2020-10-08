using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PessoaApplication : ApplicationBase<Pessoa, PessoaDTO>, IPessoaApplication
    {
        protected readonly IPessoaService pessoaService;
        public PessoaApplication(IMapper map, IPessoaService service) : base(map, service)
        {
            pessoaService = service;
        }

        public PessoaDTO GetByEmailSenha(string email, string senha)
        {
            var result = pessoaService.GetByEmailSenha(email, senha);

            if (result != null)
            {
                return _map.Map<PessoaDTO>(result);
            }

            return null;
        }

        public UsuarioLogadoDTO Login(LoginDTO data)
        {
            var usuario = this.GetByEmailSenha(data.Email, data.Senha);
            if (usuario == null)
            {
                throw new Exception("Email ou senha inválido");
            }
            else
            {
                return this.GerarToken(usuario);
            }
        }

        private UsuarioLogadoDTO GerarToken(PessoaDTO user)
        {
            var usuario = _map.Map<Pessoa>(user);
            var token = TokenService.GenerateToken(usuario);
            return new UsuarioLogadoDTO
            {
                Nome = user.Nome,
                Token = "Bearer " + token
            };
        }
    }
}
