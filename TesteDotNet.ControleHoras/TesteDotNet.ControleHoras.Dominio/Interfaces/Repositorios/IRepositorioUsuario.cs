using Dominio.Principal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;

namespace Dominio.Principal.Interfaces.Repositorios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Task<Usuario> GetUsuario(string nomeUsuario, string senha);
    }
}
