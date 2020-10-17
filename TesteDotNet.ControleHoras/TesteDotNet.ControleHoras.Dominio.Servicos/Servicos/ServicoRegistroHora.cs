using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace TesteDotNet.ControleHoras.Dominio.Servicos.Servicos
{
    public class ServicoRegistroHora : ServicoBase<RegistroHora>, IServicoRegistroHora
    {
        private readonly IRepositorioRegistroHora _repositorioRegistroHora;

        public ServicoRegistroHora(IRepositorioRegistroHora repositorioRegistroHora) : base(repositorioRegistroHora)
        {
            _repositorioRegistroHora = repositorioRegistroHora;
        }
    }
}
