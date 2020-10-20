using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Repositorios;
using Dominio.Principal.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Servicos;

namespace Dominio.Servicos.Servicos
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
                
        public Task<Usuario> GetByUsuarioSenha(string usuario, string senha)
        {
            return _repositorioUsuario.GetUsuario(usuario, senha);
        }
    }
}
