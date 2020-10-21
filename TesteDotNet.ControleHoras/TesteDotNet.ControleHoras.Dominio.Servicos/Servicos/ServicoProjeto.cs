using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace TesteDotNet.ControleHoras.Dominio.Servicos.Servicos
{
    public class ServicoProjeto : ServicoBase<Projeto>, IServicoProjeto
    {
        private readonly IRepositorioProjeto _repositorioProjeto;

        public ServicoProjeto(IRepositorioProjeto repositorioProjeto) : base(repositorioProjeto)
        {
            _repositorioProjeto = repositorioProjeto;
        }
    }
}
