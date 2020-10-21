using Dominio.Principal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;

namespace Dominio.Principal.Interfaces.Servicos
{
    public interface IServicoUsuario : IServicoBase<Usuario>
    {
        Task<Usuario> GetByUsuarioSenha(string usuario, string senha);        
    }
}
